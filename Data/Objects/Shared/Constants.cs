using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Objects.Shared
{
    public enum NameIdx : int { GROUP, ID, FIRST, MIDDLE, LAST, DATE }
    public enum AddressIdx : int { GROUP, ID, STREET, CITY, STATE, ZIP, DATE } // AddressIdx
    public enum EmailIdx : int { GROUP, ID, URL }
    public enum PhoneIdx : int { GROUP, ID, AREA, NUMBER, TYPE, DATE }
    public enum AssociationIdx : int { GROUP, PARENT, PARENTID, CHILD, CHILDID }

    public enum AddressGroups : int
    {
        ADDRESS,    // LineText1 Street, LineText2 City, LineText3 State,  LineText4 zip
        PHONE,      // LineText1 AreaCode, LineText2 Number
        EMAIL       // LineText1 URL
    }
    public enum NameGroups : int
    {
        SUPPLIER    ,
        FRANCHESEE,
        EMPLOYEE   ,
        CLIENT        ,
        CUSTOMER   ,
        VISITOR      ,
        BUYER        ,
        OWNER       , 
    }
    public enum ItemsIdx : int
    {
        ACTUALVALUE            ,
        COST                        ,
        DEPTHINCHES            ,
        HEIGHTINCHES            ,
        INVENTORYVALUE       ,
        NEWVALUE                ,
        WEIGHT                    ,
        WIDTHINCHES            ,
        DESCRIPTION            ,
        GROUP                     ,
        INVENTORYID            ,
        ITEMID                      ,
        MATERIAL                  ,
        MODELNUMBER          ,
        PRODUCTID              ,
        SERIALNUMBER         
    }

}
