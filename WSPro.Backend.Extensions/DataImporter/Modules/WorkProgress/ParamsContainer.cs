using System.Collections.Generic;
using WSPro.Backend.Domain.Model;

namespace WSPro.Backend.Extensions.DataImporter.Modules.WorkProgress
{
    public class ParamsContainer
    {
        public Element Element;
        public List<CustomParamValue> ParamValues = new();

        public void AddElement(Element element)
        {
            Element = element;
        }

        public void AddCustomParam(CustomParamValue customParam)
        {
            ParamValues.Add(customParam);
        }
    }
}