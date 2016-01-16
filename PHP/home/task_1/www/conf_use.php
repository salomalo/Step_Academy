<?php

//load xml file
$conf = simplexml_load_file('config.xml');
$color = $conf->color[0];
$bgcolor = $conf->bgcolor[0];
$nsize = $conf->size[0];
$nborder = $conf->style[0]->border[0];



print("<div bgcolor='red'    >test</div>");