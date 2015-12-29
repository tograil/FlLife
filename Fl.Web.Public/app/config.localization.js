(function (app) {
    'use strict';

    app.root.value('localeConf', {
        basePath: 'app/languages',
        defaultLocale: 'ru-RU',
        sharedDictionary: 'common',
        fileExtension: '.lang.json',
        persistSelection: true,
        cookieName: 'COOKIE_LOCALE_LANG',
        observableAttrs: new RegExp('^data-(?!ng-|i18n)'),
        delimiter: '::',
        validTokens: new RegExp('^[\\w\\.-]+\\.[\\w\\s\\.-]+\\w(:.*)?$')
    });

    app.root.value('localeSupported', [
        'en-US',
        'uk-UA',
        'ru-RU'
    ]).value('localeFallbacks', {
        'en': 'en-US',
        'uk': 'uk-UA',
        'ru': 'ru-RU'
    });

})(flLifeApp);