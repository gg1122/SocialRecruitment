/**
 * @license Copyright (c) 2003-2013, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.html or http://ckeditor.com/license
 */


CKEDITOR.editorConfig = function (config) {
    config.image_previewText = ' '; //Ԥ��������ʾ����
    config.filebrowserImageUploadUrl = "admin/UserArticleFileUpload.do"; //����Ҫ�ϴ���action��servlet

    config.toolbarGroups = [
          { name: 'basicstyles', groups: ['basicstyles', 'cleanup'] },
            { name: 'paragraph', groups: ['list'] },
		{ name: 'insert' },
		{ name: 'tools' }
    ];
   
    config.extraPlugins = 'codesnippet';

    // ȡ������ק�Ըı�ߴ硱���� plugins / resize / plugin.js
    // config.resize_enabled = false;
    config.entities_greek = true; // �Ƿ�ת��һЩ������ʾ���ַ�Ϊ��Ӧ�� HTML�ַ� 
    //config.fontSize_defaultLabel = '12px';
    config.language = 'zh-cn';
    //������Ĭ���Ƿ�չ��
    config.toolbarStartupExpanded = true;
    // config.toolbarCanCollapse = true;
    // Remove some buttons, provided by the standard plugins, which we don't
    // need to have in the Standard(s) toolbar.

    config.enterMode = CKEDITOR.ENTER_BR;
    config.shiftEnterMode = CKEDITOR.ENTER_P;
    config.removeButtons = 'Iframe,HorizontalRule,Table,IFrame,Flash,Smiley,SpecialChar,PageBreak,Copy,Paste,Undo,Redo,Anchor,Underline,Strike,Subscript,Superscript';

    config.removeDialogTabs = 'image:advanced;link:advanced';
};
