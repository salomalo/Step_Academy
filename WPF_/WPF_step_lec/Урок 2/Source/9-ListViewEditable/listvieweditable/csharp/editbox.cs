using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows;
using System.Diagnostics;
using System.Windows.Documents;
using System.Windows.Media;

namespace Editing
{
   
    public class EditBox : Control
    {
    

       
        static EditBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(EditBox), 
                new FrameworkPropertyMetadata(typeof(EditBox)));
        }

       

        
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            TextBlock textBlock = GetTemplateChild("PART_TextBlockPart") 
                   as TextBlock;
            Debug.Assert(textBlock != null, "No TextBlock!");

            _textBox = new TextBox();
            _adorner = new EditBoxAdorner(textBlock, _textBox);
            AdornerLayer layer = AdornerLayer.GetAdornerLayer(textBlock);
            layer.Add(_adorner);

            _textBox.KeyDown += new KeyEventHandler(OnTextBoxKeyDown);
            _textBox.LostKeyboardFocus += 
              new KeyboardFocusChangedEventHandler(OnTextBoxLostKeyboardFocus);

             
            HookTemplateParentResizeEvent();

            HookItemsControlEvents();

            _listViewItem = GetDependencyObjectFromVisualTree(this, 
                typeof(ListViewItem)) as ListViewItem;

            Debug.Assert(_listViewItem != null, "No ListViewItem found");
        }

        

        
        protected override void OnMouseEnter(MouseEventArgs e)
        {
            base.OnMouseEnter(e);
            if (!IsEditing && IsParentSelected)
            {
                _canBeEdit = true;
            }
        }
        
        protected override void OnMouseLeave(MouseEventArgs e)
        {
            base.OnMouseLeave(e);
            _isMouseWithinScope = false;
            _canBeEdit = false;
        }
        
        protected override void OnMouseUp(MouseButtonEventArgs e)
        {
            base.OnMouseUp(e);

            if (e.ChangedButton == MouseButton.Right || 
                e.ChangedButton == MouseButton.Middle)
                return;

            if (!IsEditing)
            {
                if (!e.Handled && (_canBeEdit || _isMouseWithinScope))
                {
                    IsEditing = true;
                }

                
                if (IsParentSelected)
                    _isMouseWithinScope = true;
            }
        }
       

        

       
        public static readonly DependencyProperty ValueProperty =
                DependencyProperty.Register(
                        "Value",
                        typeof(object),
                        typeof(EditBox),
                        new FrameworkPropertyMetadata(null));
       
         public object Value
        {
            get { return GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

       
       
        public static DependencyProperty IsEditingProperty =
                DependencyProperty.Register(
                        "IsEditing",
                        typeof(bool),
                        typeof(EditBox),
                        new FrameworkPropertyMetadata(false));
        
        public bool IsEditing
        {
            get { return (bool)GetValue(IsEditingProperty); }
            private set
            {
                SetValue(IsEditingProperty, value);
                _adorner.UpdateVisibilty(value);
            }
        }

        

      
        private bool IsParentSelected
        {
            get
            {
                if (_listViewItem == null)
                    return false;
                else
                    return _listViewItem.IsSelected;
            }
        }

      

       
        private void OnTextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (IsEditing && (e.Key == Key.Enter || e.Key == Key.F2))
            {
                IsEditing = false;
                _canBeEdit = false;
            }
        }

        
        private void OnTextBoxLostKeyboardFocus(object sender, 
                                             KeyboardFocusChangedEventArgs e)
        {
            IsEditing = false;
        }

       
        private void OnCouldSwitchToNormalMode(object sender, 
                                               RoutedEventArgs e)
        {
            IsEditing = false;
        }

       
        private void HookItemsControlEvents()
        {
            _itemsControl = GetDependencyObjectFromVisualTree(this, 
                                typeof(ItemsControl)) as ItemsControl;
            if (_itemsControl != null)
            {
               
                _itemsControl.SizeChanged += 
                    new SizeChangedEventHandler(OnCouldSwitchToNormalMode);
                _itemsControl.AddHandler(ScrollViewer.ScrollChangedEvent, 
                    new RoutedEventHandler(OnScrollViewerChanged));
                _itemsControl.AddHandler(ScrollViewer.MouseWheelEvent, 
                    new RoutedEventHandler(OnCouldSwitchToNormalMode), true);
            }
        }

        
        private void OnScrollViewerChanged(object sender, RoutedEventArgs args)
        {
            if (IsEditing && Mouse.PrimaryDevice.LeftButton == 
                                MouseButtonState.Pressed)
            {
                IsEditing = false;
            }
        }

        
        private DependencyObject 
            GetDependencyObjectFromVisualTree(DependencyObject startObject, 
                                              Type type)
        {
           
            DependencyObject parent = startObject;
            while (parent != null)
            {
                if (type.IsInstanceOfType(parent))
                    break;
                else
                    parent = VisualTreeHelper.GetParent(parent);
            }

            return parent;
        }

        /
        private void HookTemplateParentResizeEvent()
        {
            FrameworkElement parent = TemplatedParent as FrameworkElement;
            if (parent != null)
            {
                parent.SizeChanged += 
                    new SizeChangedEventHandler(OnCouldSwitchToNormalMode);
            }
        }

       
        
        private EditBoxAdorner _adorner; 
       
        private FrameworkElement _textBox;
       
        private bool _canBeEdit = false;
      
        private bool _isMouseWithinScope = false;
        
        private ItemsControl _itemsControl;
        
        private ListViewItem _listViewItem;

      
   
    }
   

}
