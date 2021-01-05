using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//chacune des fctions ouvre le kovets, lit qq chose et est mahzir cette chose
//faire attention a s occuper des harigots
using DLAPI;
//using DO;
using DS;

namespace DL
{
    sealed class DLObject : IDAL    //internal //af ehad yahol larechet

    {

        public void AddBus(DO.Bus bus)
        {

            //DO.Person per = DataSource.ListPersons//oleh larechimot.Find(p => p.ID == id)//est mafil la fction find //avour kal evar p si le Id est egal a celui de person(celui qui a ete recu);
            //if (per != null)//
            //    DataSource.ListPerson.Add (per.Clone());//tamid maatikim netounim //copie ds ma list//CLONE=copy ctor
            //else
            //    throw new DO.BadPersonIdException(id, $"bad person id: {id}");//exceptions ds Do

            DO.Bus myBus = DataSource.ListBus.Find(b => b.LicenseNum == bus.LicenseNum);
            if (myBus != null)
                DataSource.ListBus.Add(myBus.Clone());
            else
                throw new DO.BadBusIdException(bus.LicenseNum, $"bad bus license number: {bus.LicenseNum}") ;//exceptions ds Do
        }

    }  
 }

