using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BL
{// pour pouvoir prendre plusieurs mahlakots et les rassembler en 1 (ex list de notes chez le student). du cp different de clone
    static class DeepCopyUtilities
    {
        public static void CopyPropertiesTo<T, S>(this S from, T to)
        {
            foreach (PropertyInfo propTo in to.GetType().GetProperties())
            {
                PropertyInfo propFrom = typeof(S).GetProperty(propTo.Name);
                if (propFrom == null)
                    continue;
                var value = propFrom.GetValue(from, null);
                if (value is ValueType || value is string)
                    propTo.SetValue(to, value);
            }
        }
        public static object CopyPropertiesToNew<S>(this S from, Type type)
        {
            object to = Activator.CreateInstance(type); // new object of Type
            from.CopyPropertiesTo(to);
            return to;
        }
        public static BO.LineStation CopyToLineStation(this DO.LineStation Station)
        {
            BO.LineStation result = (BO.LineStation)Station.CopyPropertiesToNew(typeof(BO.LineStation));
            ////a completer si besoin propertys' names changed? copy them here...
            //result.Grade = sic.Grade;
            return result;
        
        }



       
    }
}








}
