/// <reference path="../ckfinder/ckfinder.js" />
/// <reference path="../ckfinder/ckfinder.js" />
/**
 * @license Copyright (c) 2003-2021, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
	// config.uiColor = '#AADC6E';

	config.extraPlugins = 'syntaxhighlight';
	config.syntaxhighlight_lang = 'csharp';
	config.syntaxhighlight_hideControls = true;
	config.language = 'vi';
	config.filebrowserBrowseUrl = '~/Assets/plugins/ckfinder/ckfinder.html';
	config.filebrowserImageBrowseUrl = '~/Assets/plugins/ckfinder/ckfinder.html?Type=Image';
	config.filebrowserFlashBrowseUrl = '~/Assets/plugins/ckfinder/ckfinder.html?Type=Flash';
	config.filebrowserUploadUrl = '~/Assets/plugins/ckfinder/core/connector/aspx/connector.asp?command=QuickUpload&type=File';
	config.filebrowserImageUploadUrl = '/Data';
	config.filebrowserFlashUploadUrl = '~/Assets/plugins / ckfinder / core / connector / aspx / connector.asp ?command=QuickUpload&type=Flash';
	CKFinder.setupCKEditor(null, '~/Assets/plugins/ckfinder/')
};
