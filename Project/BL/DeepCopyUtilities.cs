using DO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DL;

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

//transforme le type de "from" en type "type"
        public static object CopyPropertiesToNew<S>(this S from, Type type)
        {
            object to = Activator.CreateInstance(type); // new object of Type
            from.CopyPropertiesTo(to);
            return to;
        }
        public static BO.LineStation CopyToLineStation(this DO.LineStation lineStation)
        {
            BO.LineStation result = (BO.LineStation)lineStation.CopyPropertiesToNew(typeof(BO.LineStation));

            DO.Station myStation =  GetStation(lineStation.StationCode);
            result.StationName = myStation.Name;
            int previousIndex = --(lineStation.LineStationIndex);
            DO.AdjacentStations adj = GetAdjacentStations(myStation,GetStation(mettre ici le code de la station previous)); 
            result.DistanceFromLastStation = ;
            result.TimeFromLastStation = ;
            //DL.GetAllAdjacentStationsBy(adj => adj.station2 == stat);

            return result;

        }

        //public DO.Station GetPreviousStation(DO.LineStation lineStation) //jve la previous station de( ouziel, 21 )
        //{
        //    int line = lineStation.LineId;//line = 21
        //    IEnumerable<DO.AdjacentStations> list = GetAllAdjacentStationsBy(adj => adj.Station2 == lineStation.StationCode);
        //    //list d'adj tel que la 2e station est ouziel 
        //    //reste a verif que la 1ere est une station ou passe le 21 
        //    //la previous station est celle ci (la premiere des adj) 
        //    (list.ToList()).Find(adj => adj.Station1 == lineStation.StationCode);
        //    //la adj tel que 2e station est ouziel est premiere station est 
        //    // from station in list select station.Clone();
        //}



        //fonction sur un courseDO qui recoit un sicDO et qui copie ca a un sicBO
        public static BO.StudentCourse CopyToStudentCourse(this DO.Course course, DO.StudentInCourse sic)
        {
            BO.StudentCourse result = (BO.StudentCourse)course.CopyPropertiesToNew(typeof(BO.StudentCourse));
            // propertys' names changed? copy them here...
            result.Grade = sic.Grade;
            return result;
        }



    }
}








}
