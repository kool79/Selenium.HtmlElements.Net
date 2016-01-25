﻿using System;
using OpenQA.Selenium;

namespace HtmlElements.LazyLoad
{
    internal class WebElementLoader : CachingLoader<IWebElement>
    {
        private readonly By _locator;

        private readonly ISearchContext _searchContext;

        public WebElementLoader(ISearchContext searchContext, By locator, Boolean enableCache) : base(enableCache)
        {
            _searchContext = searchContext;
            _locator = locator;
        }

        protected override IWebElement ExecuteLoad()
        {
            return _searchContext.FindElement(_locator);
        }

        public override string ToString()
        {
            return String.Format("Loader for element located by [{0}] in [{1}]", _locator, _searchContext);
        }
    }
}