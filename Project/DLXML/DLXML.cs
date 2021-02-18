using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DLAPI;
using DO;

namespace DL
{
    sealed class DLXML : IDAL    //internal
        {
            #region singelton
            static readonly DLXML instance = new DLXML();
            static DLXML() { }// static ctor to ensure instance init is done just before first usage
            DLXML() { } // default => private
            public static DLXML Instance { get => instance; }// The public Instance property to use
            #endregion

            #region DS XML Files

            string linePath = @"LineXml.xml"; //XElement
            string stationPath = @"StationXml.xml"; //XMLSerializer
            string lineStationPath = @"LineStationXml.xml"; //XMLSerializer
            string adjacentStationPath = @"AdjacentsStationXml.xml"; //XMLSerializer
           

            #endregion

            #region Line
            public DO.Line GetLine(int code)
            {
                XElement lineRootElem = XMLTools.LoadListFromXMLElement(linePath);

                 Line l= (from line in lineRootElem.Elements()
                            where int.Parse(line.Element("CODE").Value) == code
                            select new Line()
                            {
                                Id = Int32.Parse(line.Element("ID").Value),
                                Code = Int32.Parse(line.Element("Code").Value),
                                Area= (DO.Enums.Areas)Enum.Parse(typeof(DO.Enums.Areas), line.Element("Area").Value),
                                FirstStation= Int32.Parse(line.Element("FirstStation").Value),
                                LastStation = Int32.Parse(line.Element("LastStation").Value),
         
                            }
                            ).FirstOrDefault();

                if (l == null)
                    throw new DO.BadLineIdException(code, $"bad line code: {code}");

                return l;
            }
        }
    }
}
