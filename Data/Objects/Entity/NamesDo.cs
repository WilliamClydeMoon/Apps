using System;
//using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using System.Text;
using System.IO;
using Common.Extensions;
//using Data.Objects;
//using System.Text.RegularExpressions;
using Data.Objects.Shared;
using Data.DataAccess;
using Common.Utility.Type;


namespace Data.Objects
{
    public class NamesDo
    {
        private List<Name> _names;
        //private List<string> _Ids = new List< string>() ;

        private bool _getall;
        private string _group;
        private string _parentId;

        public List<string> Ids = new List<string>();

        #region Constructor
        /*___________________________________________________________________________________________*/
        public NamesDo()
        {
            GetAll = false;
            Names = new List<Name>();
        }

        public NamesDo(string group) 
        {
            this.Group = group;
            GetAll = false;
            Names = new List<Name>();
        }

        #endregion
        #region private members
        /*___________________________________________________________________________________________*/
        public string Group { get { return _group; } set { _group = value; } }
        /*___________________________________________________________________________________________*/
        public string ParentId { get { return _parentId; } set { _parentId = value; } }
        /*___________________________________________________________________________________________*/
        public string Id { get; set; }// ;
        /*__________________________________________________________________________________________*/
        public bool GetAll
        {
            get
            {
                if (_getall == null)
                    _getall = false;

                return _getall;
            }
            set { _getall = value; }
        }
        /*__________________________________________________________________________________________*/
        public void ReSet()
        {
            _group = null;
            _parentId = null;
            GetAll = false;
            Ids.Clear();
            Names.Clear();
        }
        /*__________________________________________________________________________________________*/
        public List< Name > Names
        {
            get
            {
                if (_names == null)
                    _names = new List<Name>();

                return _names;
            }
            set { _names = value; }
        }
        #endregion
        #region Fetch Data
        /*__________________________________________________________________________________________*/
        public List< string > NamesList()
        {
            List<string> namelist = new List<string>();
            foreach (var name in Names )
                namelist.Add(name.NameArray.StringConcatenate());

            return namelist;

        }
        /*__________________________________________________________________________________________*/
        public List<string> NamesList( Name name )
        {
            List<string> namelist = new List<string>();
           
                namelist.Add( name.NameArray.StringConcatenate( ));

            return namelist;

        }
        /*__________________________________________________________________________________________*/
        public List<PairType<string , string> > GetPairedNameAndId()
        {
            //List<PairType<string, string>> returnVal = new List<PairType<string, string>>();  
            //var returnVal = Names.Select(pair => new PairType<string , string>(pair.NameId , pair.FullName)).ToList();

            return Names.Select(pair => new PairType<string, string>( pair.FullName,pair.NameId)).ToList();
        }
        /*__________________________________________________________________________________________*/
        //public List<Name> GetUniqueNamesById()
        public void GetUniqueNamesById()
        {
            //var distinctResult = from c in result
            //                     group c by c.Id into uniqueIds
            //                     select uniqueIds.FirstOrDefault();
            //TODO Write logic to get unique set of names
            //return Names;
            //Names.Distinct(items => items.NameId).ToList();someTable.Select(r => new { r.attribute1_name, r.attribute2_name }).Distinct();
            //var n = Names.Select(r => new { r.NameId}).Distinct();
            //var d = distinctNames = from items in names orderby items 
            //var d = Names.GroupBy(item => item.NameId).Select(name => name.s).ToList();
            //var  n = Names .OrderBy(names => names.SysDateTime  ).ToList(); //OrderBy(item => item.NameId , item => item.sysDateTime)

            //foreach( var name in d)
                

            //return d;
        }
        /*__________________________________________________________________________________________*/
        public Name GetBestName(string id)
        {
            //return GetNamesInDateOrderById(id).Select(item => item.SysDateTime < item.SysDateTime);
            
            //FindLast(item => item.NameId == id);

            return GetNamesInDateOrderById(id).FindLast(item => item.NameId == id);

            //return Names.FindAll(item => item.NameId == id).OrderBy(item => item.SysDateTime).ToList();
        }
        /*__________________________________________________________________________________________*/
        public List<Name> GetNamesInDateOrderById(string id)
        {
            // Group names by NameId and return the list in SysDateTime order 
           return Names.FindAll(item => item.NameId == id).OrderBy(item => item.SysDateTime ).ToList();
        }
        /*__________________________________________________________________________________________*/
        public List<Name>GetNamesInDateOrder()
        {
            return Names.OrderBy(item => item.SysDateTime).ToList();
        }
        /*__________________________________________________________________________________________*/
        public List<string> GetUniqueGroups()
        {
            //var results = Names.Distinct(items => items.Group).ToList();
            var results = Names.Distinct(items => items.Group).ToList(); //.Sort( Group.);
            results.Sort();
            //Names.Sort(name => name.Group);
            return results;
        }
                /*__________________________________________________________________________________________*/
        //public List<NamesDo > GetGroupList(string group )
        //{
        //    //return = Names.FindAll(items => items.Group.ToString() == group ).ToList();
            
        //}

        #endregion
        #region Data
        /*__________________________________________________________________________________________*/
        public void Add(Name dataObject)
        {
            Names.Add(dataObject);
        }
        /*__________________________________________________________________________________________*/
        public void LoadData()
        {
            if (Names.IsNullOrEmpty())
            {
                string file = "Names.csv";
                string path = @"C:\MyStuff\Dev\Apps\Data\Communication\Test\Pull\";
                string filePath = path + file;
                System.Nullable<bool> isGroup = !Group.IsNullOrEmpty();
                System.Nullable<bool> isIdsEmpty = Ids.IsNullOrEmpty();
                bool matchParentGroup = true;

                var records = File.ReadLines(filePath).Select(
                    line => line.RemoveCharacters("\"").Split(',')).
                    Where(data =>
                              {
                                  return GetAll               //ALL
                                              ? true            //GROUP
                                              : isIdsEmpty.Value  ? true : Ids.FindIndex(val_ => val_ == data[(int)NameIdx.ID]) >= 0;
                              }).Select(
                        items => new Name()
                                     {
                                         NameId = items[(int) NameIdx.ID],
                                         First = items[(int) NameIdx.FIRST],
                                         Middle = items[(int) NameIdx.MIDDLE],
                                         Last = items[(int) NameIdx.LAST],
                                         FullName = items[(int)NameIdx.FIRST] + "  " + items[(int)NameIdx.MIDDLE] + " " +items[(int) NameIdx.LAST],
                                         SysDateTime = DateTime.Parse(items[(int) NameIdx.DATE]),
                                         Group = items[(int) NameIdx.GROUP]
                                     });
                //Select(z => { return z; })
                // filter out the values by group if passed in.
                var lines = records.Select(line => line)
                    .Where(line =>
                    {
                        if (isGroup.HasValue && isGroup.Value)
                            matchParentGroup = line.Group == Group; // _parentgroup;

                        return matchParentGroup;
                    }).ToList();

                foreach (var items in lines)
                {
                    Names.Add(items);
                }
            }
        }
        #endregion
    }
}
