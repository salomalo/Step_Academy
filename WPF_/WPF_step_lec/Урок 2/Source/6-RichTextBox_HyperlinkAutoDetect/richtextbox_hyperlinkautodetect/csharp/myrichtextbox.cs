using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace HyperlinkAutoDetect
{
   
    public class MyRichTextBox : RichTextBox
    {
        
        static MyRichTextBox()
        {
            
            EventManager.RegisterClassHandler(typeof(MyRichTextBox), KeyDownEvent, new KeyEventHandler(OnKeyDown), /*handledEventsToo*/true);
        }

        
        private static void OnKeyDown(object sender, KeyEventArgs e)
        {
            MyRichTextBox myRichTextBox = (MyRichTextBox)sender;

            if (e.Key != Key.Space && e.Key != Key.Back && e.Key != Key.Return)
            {
                return;
            }

            if (!myRichTextBox.Selection.IsEmpty)
            {
                myRichTextBox.Selection.Text = String.Empty;
            }

            TextPointer caretPosition = myRichTextBox.Selection.Start;

            if (e.Key == Key.Space || e.Key == Key.Return)
            {
                TextPointer wordStartPosition;
                string word = GetPreceedingWordInParagraph(caretPosition, out wordStartPosition);

                if (word == "www.microsoft.com") 
                {
                    
                    new Hyperlink(
                        wordStartPosition.GetPositionAtOffset(0, LogicalDirection.Backward),
                        caretPosition.GetPositionAtOffset(0, LogicalDirection.Forward));

                    
                }
            }
            else 
            {
                TextPointer backspacePosition = caretPosition.GetNextInsertionPosition(LogicalDirection.Backward);
                Hyperlink hyperlink;
                if (backspacePosition != null && IsHyperlinkBoundaryCrossed(caretPosition, backspacePosition, out hyperlink))
                {
                    
                    TextPointer newCaretPosition = caretPosition.GetPositionAtOffset(0, LogicalDirection.Forward);

                    
                    InlineCollection hyperlinkChildren = hyperlink.Inlines;
                    Inline[] inlines = new Inline[hyperlinkChildren.Count];
                    hyperlinkChildren.CopyTo(inlines, 0);

                    
                    for (int i = inlines.Length - 1; i >= 0; i--)
                    {
                        hyperlinkChildren.Remove(inlines[i]);
                        hyperlink.SiblingInlines.InsertAfter(hyperlink, inlines[i]);
                    }

                    
                    LocalValueEnumerator localProperties = hyperlink.GetLocalValueEnumerator();
                    TextRange inlineRange = new TextRange(inlines[0].ContentStart, inlines[inlines.Length - 1].ContentEnd);

                    while (localProperties.MoveNext())
                    {
                        LocalValueEntry property = localProperties.Current;
                        DependencyProperty dp = property.Property;
                        object value = property.Value;

                        if (!dp.ReadOnly &&
                            dp != Inline.TextDecorationsProperty && 
                            dp != TextElement.ForegroundProperty &&
                            !IsHyperlinkProperty(dp))
                        {
                            inlineRange.ApplyPropertyValue(dp, value);
                        }
                    }

                 
                    hyperlink.SiblingInlines.Remove(hyperlink);

                   
                    myRichTextBox.Selection.Select(newCaretPosition, newCaretPosition);
                }
            }
        }

        
        private static bool IsHyperlinkProperty(DependencyProperty dp)
        {
            return dp == Hyperlink.CommandProperty ||
                dp == Hyperlink.CommandParameterProperty ||
                dp == Hyperlink.CommandTargetProperty ||
                dp == Hyperlink.NavigateUriProperty ||
                dp == Hyperlink.TargetNameProperty;
        }

        
        private static bool IsHyperlinkBoundaryCrossed(TextPointer caretPosition, TextPointer backspacePosition, out Hyperlink backspacePositionHyperlink)
        {
            Hyperlink caretPositionHyperlink = GetHyperlinkAncestor(caretPosition);
            backspacePositionHyperlink = GetHyperlinkAncestor(backspacePosition);

            return (caretPositionHyperlink == null && backspacePositionHyperlink != null) ||
                (caretPositionHyperlink != null && backspacePositionHyperlink != null && caretPositionHyperlink != backspacePositionHyperlink);
        }

        
        private static Hyperlink GetHyperlinkAncestor(TextPointer position)
        {
            Inline parent = position.Parent as Inline;
            while (parent != null && !(parent is Hyperlink))
            {
                parent = parent.Parent as Inline;
            }

            return parent as Hyperlink;
        }

        
        private static string GetPreceedingWordInParagraph(TextPointer position, out TextPointer wordStartPosition)
        {
            wordStartPosition = null;
            string word = String.Empty;

            Paragraph paragraph = position.Paragraph;
            if (paragraph != null)
            {
                TextPointer navigator = position;
                while (navigator.CompareTo(paragraph.ContentStart) > 0)
                {
                    string runText = navigator.GetTextInRun(LogicalDirection.Backward);

                    if (runText.Contains(" ")) 
                    {
                        int index = runText.LastIndexOf(" ");
                        word = runText.Substring(index + 1, runText.Length - index - 1) + word;
                        wordStartPosition = navigator.GetPositionAtOffset(-1 * (runText.Length - index - 1));
                        break;
                    }
                    else
                    {
                        wordStartPosition = navigator;
                        word = runText + word;
                    }
                    navigator = navigator.GetNextContextPosition(LogicalDirection.Backward);
                }
            }

            return word;
        }
    }
}