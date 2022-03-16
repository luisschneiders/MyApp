using System;
using System.Collections.Generic;

namespace BaseLibrary
{
    public class ComponentMarkup : IComponentMarkup
    {
        public string Title { get; set; }
        public List<string> Code { get; set; }
    }
}
