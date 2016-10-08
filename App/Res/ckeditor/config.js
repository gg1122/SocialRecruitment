/**
 * @license Copyright (c) 2003-2016, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here.
	// For complete reference see:
	// http://docs.ckeditor.com/#!/api/CKEDITOR.config
    config.image_previewText = ' '; //预览区域显示内容
    config.filebrowserImageUploadUrl = "/Publish/CententOfImage"; //待会要上传的action或servlet
    config.toolbarGroups = [
            { name: 'basicstyles', groups: ['basicstyles'] },
              { name: 'paragraph', groups: ['list'] },
          { name: 'insert' },
          { name: 'tools' }
    ];


	// Remove some buttons provided by the standard plugins, which are
	// not needed in the Standard(s) toolbar.
    config.removeButtons = 'Italic,Table,Anchor,SpecialChar,HorizontalRule,Underline,Strike,Subscript,Superscript';
      

	// Simplify the dialog windows.
	config.removeDialogTabs = 'image:advanced;link:advanced';
};
