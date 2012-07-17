using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Common.Utility.Type;
using Common.Extensions;
using Data.Objects.Shared;
using Data.DataAccess;

namespace Data.Objects
{
    public class AssociationsDo
    {

        private List<Association> _associations;
        public List<string> Ids  = new List<string>();

        private string _Id;

        private bool _getall;
        private int _idtype;
        private string _parentgroup;
        private string _childgroup;
        private string _parentId;
        private string _childId;

        #region Contstructor
        /*__________________________________________________________________________________________*/
        public AssociationsDo( )
        {
            GetAll = false;
            Associations = new List<Association>();
        }
        ///*__________________________________________________________________________________________*/
        //public AssociationsDo(string groupname, string Id, string instructions)
        //{
        //    //parentgroup/parentid    parentparent
        //    //parentgroup/childid      parentchild
        //    //childname/childid         childchild
        //    //childname/parentid      childparent

        //    instructions = instructions.ToUpper();
        //    if ( instructions == "PARENTPARENT")
        //    {
        //        _parentgroup = groupname;
        //        _parentId = Id;
        //        IDType = (int)AssociationIdx.PARENTID;
        //    }
        //    else if(instructions == "PARENTCHILD")
        //    {
        //        _parentgroup = groupname;
        //        _childId  = Id;
        //        IDType = (int)AssociationIdx.CHILDID;
        //    }
        //    else if(instructions == "CHILDCHILD")            
        //    {
        //        _childgroup = groupname;
        //        _childId = Id;
        //        IDType = (int)AssociationIdx.CHILDID;
        //    }
        //    else if(instructions == "CHILDPARENT")
        //    {
        //        IDType = (int)AssociationIdx.PARENTID;
        //        _childgroup = groupname;
        //        _parentId = Id;
        //    }

        //    Ids.Add(Id);
        //}
        ///*__________________________________________________________________________________________*/
        //public AssociationsDo(string parentgroup, string Id, string childgroup, string instructions)
        //{
        //    instructions = instructions.ToUpper();
        //    if (instructions == "PARENT")
        //    {
        //        IDType = (int)AssociationIdx.PARENTID;
        //        _parentId = Id;
        //    }
        //    else if (instructions == "CHILD")
        //    {
        //        IDType = (int)AssociationIdx.CHILDID;
        //        _childId = Id;
        //    }
        //    // Load Data where ParentGroup = parentgroup
        //    Ids.Add(Id);
        //    _parentgroup = parentgroup;
        //    _childgroup = childgroup;

        //}
        ///*__________________________________________________________________________________________*/
        //public AssociationsDo(List<string > Ids, string grouptype )
        //{
        //}
        ///*__________________________________________________________________________________________*/
        //public AssociationsDo(bool getall )
        //{
        //    GetAll = true;
        //}
        ///*__________________________________________________________________________________________*/
        //public AssociationsDo(string grouptype)
        //{
        //}

#endregion
        #region private members        

        /*___________________________________________________________________________________________*/
        public int IDType { get { return _idtype; } set { _idtype = value; } }
        /*___________________________________________________________________________________________*/
        public string ParentGroup { get { return _parentgroup; } set { _parentgroup = value; } }
        /*___________________________________________________________________________________________*/
        public string ChildGroup { get { return _childgroup; } set { _childgroup = value; } }
        /*___________________________________________________________________________________________*/
        public string ParentId { get { return _parentId; } set { _parentId = value; } }
        /*___________________________________________________________________________________________*/
        public string ChildId { get { return _childId; } set { _childId = value; } }
        /*___________________________________________________________________________________________*/
        public string Id { get; set; }// ;
        /*__________________________________________________________________________________________*/
        public string Group { get; set; }// 
        /*__________________________________________________________________________________________*/
        public List<Association> Associations 
                { 
                    get
                    {
                        if (_associations == null)
                            _associations = new List<Association>();
                        return _associations;
                    } 
                    set { _associations = value; } 
                }
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
                _parentgroup = null;
                _childgroup = null;
                _parentId = null;
                _childId = null;
                GetAll = false;
                Ids.Clear();
                Associations.Clear();
        }
        #endregion
        #region Fetch Data
        /*__________________________________________________________________________________________*/
        public void ReviewTestData(List<Association > list , string msg )
        {
            Console.WriteLine(msg);
            foreach (var line in list)
                Console.WriteLine(line.AssociationArray.StringConcatenate());

        }
        #region UNIQUE GROUPS
        /*__________________________________________________________________________________________*/
        public List<string> GetUniqueParentGroups()
        {
            var results = Associations.Distinct(items => items.ParentGroup).ToList();
            results.Sort();
            return results;
        }
        /*__________________________________________________________________________________________*/
        public List<string> GetUniqueChildGroups()
        {
            var results = Associations.Distinct(items => items.ChildGroup).ToList();
            results.Sort();
            return results;
        }
        /*__________________________________________________________________________________________*/
        //public List<string> GetUniqueChildIdsByParentAndChildGroup(string parent, string child) //TODO Not tested
        //{
        //    //var results = Associations.Distinct(items => items.ParentGroup  && items.ChildGroup )ToList(); //Select(Ids => Ids.ChildId.ToString());
        //    //return results.ToList();
        //}
        /*__________________________________________________________________________________________*/
        public List<Association> GetAllParentIdsByParentGroup(string parent)
        {
            var results = Associations.FindAll(items => items.ParentGroup == parent ); //.Select(Ids => Ids.ParentId.ToString( ));
            return results ;
        }
        /*__________________________________________________________________________________________*/
        public List<Association> GetAllChildIdsByParentGroup(string parent)
        {
            var results = Associations.FindAll(items => items.ParentGroup == parent); //.Select(Ids => Ids.ChildId.ToString());
            return results;
        }
        /*__________________________________________________________________________________________*/
        public List<Association> GetParentIdsByParentAndChildGroup(string parent, string child)  //TODO Not tested
        {
            var results = Associations.FindAll(items => items.ParentGroup == parent && items.ChildGroup == child  ); //.Select(Ids => Ids.ParentId.ToString( ));
            return results ;
        }
        /*__________________________________________________________________________________________*/
        public List<Association> GetChildIdsByParentAndChildGroup(string parent, string child) //TODO Not tested
        {
            var results = Associations.FindAll(items => items.ParentGroup == parent && items.ChildGroup == child); //.Select(Ids => Ids.ChildId .ToString());
            return results;
        }
        #endregion
        #region BY GROUPS
        /*__________________________________________________________________________________________*/
        public List<Association> GetAllAssociationsByParentGroup(string parentgroup)
        {
            var results = Associations.FindAll(items => items.ParentGroup == parentgroup);
            return results;
        }
        #endregion
        #region BY ID
        /*__________________________________________________________________________________________*/
        public List<string> GetAllChildIdByParentId(string parentId)  // AssociationChildIdsByParentId
        {
            var records = GetAllAssociationMatchesByParentId(parentId)
                .Select(Ids => Ids.ChildId.ToString()).ToList();

            return records;
        }
        /*__________________________________________________________________________________________*/
        public List<Association> GetAllAssociationMatchesByParentId(string parentId)
        {
            var results = Associations.FindAll(items => items.ParentId == parentId);
            return results;
        }
        /*__________________________________________________________________________________________*/
        public List<Association> GetAllAssociationMatchesByChildId(string childId)
        {
            var results = Associations.FindAll(items => items.ChildId == childId);
            return results;
        }
        ///*__________________________________________________________________________________________*/
        //public List<Association> AssociationChildIdsByParentIdList(List<string> Ids )
        //{
        //    var records = record => Associations.Where( Ids.FindIndex( val_ => val_ == ) )
        //}
        ///*__________________________________________________________________________________________*/
        //public List<Association> AssociationChildIdsByChildIds(List<string> Ids)
        //{ }
        ///*__________________________________________________________________________________________*/
        //public List<Association> AssociationParentIdsByParentIdList(List<string> Ids)
        //{ }
        ///*__________________________________________________________________________________________*/
        //public List<Association> AssociationParentIdsByChildIds(List<string> Ids)
        //{ }  
        #endregion
        #region BY ID & GROUP
        /*__________________________________________________________________________________________*/
        public List<Association> GetAllAssociationMatchesByParentIdAndGroup(string parentId, string groupName)
        {
            var results = Associations.FindAll(items => (items.ParentGroup == groupName && items.ParentId == parentId));

            return results;
        }
        /*__________________________________________________________________________________________*/
        public List<Association> GetAllAssociationMatchesByChildIDAndGroup(string childId, string groupName)
        {
            var results = Associations.FindAll(items => items.ChildId == childId && items.ChildGroup == groupName);
            var results1 = Associations.Where(items => (items.ChildId == childId && items.ChildGroup.Contains(groupName)));//.ToList();

            return results1.ToList();
        }
        #endregion
        #region PAIRED GROUPING
        /*__________________________________________________________________________________________*/
        public List<PairType<string, string>> GetPairedParentGroupAndId()
        {
            //List<PairType<string, string>> returnVal = new List<PairType<string, string>>();  
            //var returnVal = Names.Select(pair => new PairType<string , string>(pair.NameId , pair.FullName)).ToList();

            return Associations .Select(pair => new PairType<string, string>(pair.ParentGroup,pair.ParentId )).ToList();
        }
        /*__________________________________________________________________________________________*/
        public List<PairType<string, string>> GetPairedParentGroupAndId(List<Association> associations)
        {
            //List<PairType<string, string>> returnVal = new List<PairType<string, string>>();  
            //var returnVal = Names.Select(pair => new PairType<string , string>(pair.NameId , pair.FullName)).ToList();

            return associations.Select(pair => new PairType<string, string>(pair.ParentGroup, pair.ParentId)).ToList();
        }
        /*__________________________________________________________________________________________*/
        public List<PairType<string, string>> GetPairedChildGroupAndId()
        {
            //List<PairType<string, string>> returnVal = new List<PairType<string, string>>();  
            //var returnVal = Names.Select(pair => new PairType<string , string>(pair.NameId , pair.FullName)).ToList();

            return Associations.Select(pair => new PairType<string, string>(pair.ChildGroup,pair.ChildId)).ToList();
        }
        /*__________________________________________________________________________________________*/
        public List<PairType<string, string>> GetPairedChildGroupAndId(List<Association> associations)
        {
            //List<PairType<string, string>> returnVal = new List<PairType<string, string>>();  
            //var returnVal = Names.Select(pair => new PairType<string , string>(pair.NameId , pair.FullName)).ToList();

            return associations.Select(pair => new PairType<string, string>(pair.ChildGroup, pair.ChildId)).ToList();
        }

        /*__________________________________________________________________________________________*/
        public List<QuadType<string, string, string, string>> GetQuadDataList(List<Association> associations)
        {
            //List<PairType<string, string>> returnVal = new List<PairType<string, string>>();  
            //var returnVal = Names.Select(pair => new PairType<string , string>(pair.NameId , pair.FullName)).ToList();

            return associations.Select(pair => new QuadType<string, string, string, string >(
                pair.ParentGroup,
                pair.ParentId, 
                pair.ChildGroup,
                pair.ChildId 
                )).ToList();
        }
        #endregion

        #endregion
        #region Data
        /*__________________________________________________________________________________________*/
        public void Add( Association dataObject)
        {
            Associations.Add(dataObject);
        }
        /*__________________________________________________________________________________________*/
        public List<Association > LoadData()
        {
            // GetAll
            // Get by group
            // get by parentId
            // get by childId
            List<Association> Records= new List<Association>( ) ;

            if (Associations.IsNullOrEmpty())
            {
                string file = "Associations.csv";
                string path = @"C:\MyStuff\Dev\Apps\Data\Communication\Test\Pull\";
                string filePath = path + file;

                //System.Nullable<bool> isParentGroup = !_parentgroup.IsNullOrEmpty() ;
                //System.Nullable<bool> isChildGroup = !_childgroup.IsNullOrEmpty() ;
                System.Nullable<bool> isParentGroup = !ParentGroup .IsNullOrEmpty();
                System.Nullable<bool> isChildGroup = !ChildGroup .IsNullOrEmpty();
                System.Nullable<bool> isIdsEmpty = Ids.IsNullOrEmpty();

                bool matchParentGroup = true;
                bool matchChildGroup = true;
                var value = isParentGroup.Value;
                //int IDType = ParentId == null ? (int)AssociationIdx.CHILDID : (int)AssociationIdx.PARENTID;

                var records = File.ReadLines(filePath).Select(
                    lines => lines.RemoveCharacters("\"").Split(',')).
                    Where(line =>
                    {
                        
                        return GetAll
                                   ? true
                                   : isIdsEmpty.Value ? true : Ids.FindIndex(val_ => val_.Trim() == line[IDType].Trim()) >= 0;
                    })
                             .Select(
                                    lines => new Association()  // TODO add logic to filter by ID
                                    {
                                        ParentGroup = lines[(int)AssociationIdx.PARENT],
                                        ParentId = lines[(int)AssociationIdx.PARENTID],
                                        ChildGroup = lines[(int)AssociationIdx.CHILD],
                                        ChildId = lines[(int)AssociationIdx.CHILDID]
                                    }).
                                    ToList();

                    
                //Select(z => { return z; })
                // filter out the values by group if passed in.
                var data = records.Select(lines => lines)
                    .Where(lines =>
                    {
                        if (isParentGroup.HasValue && isParentGroup.Value)
                            matchParentGroup = lines.ParentGroup == ParentGroup; // _parentgroup;

                        if (isChildGroup.HasValue & isChildGroup.Value)
                            matchChildGroup = lines.ChildGroup == ChildGroup; // _childgroup;

                        return matchParentGroup && matchChildGroup;

                    }).ToList();

                foreach (var items in data)
                {
                    Associations.Add(items);
                    Records.Add(items);
                }
                
                

            }
            return Records;
        }
    }
        #endregion
}


/*
var record = File.ReadLines(filePath).Select(
        lines => lines.RemoveCharacters("\"").Split(','))
    .Where(line =>
    {
        return GetAll
                   ? true
                   : Ids.FindIndex(val_ => val_ == line[(int)AssociationIdx.PARENTID]) >= 0
                     && isParentGroup.HasValue &&
                     line[(int)AssociationIdx.PARENT] == _parentgroup
                     && isChildGroup.HasValue &&
                     line[(int)AssociationIdx.CHILD] == _childgroup;
    })
.Select(
    lines => new Association() 
    {
        ParentGroup = lines[(int)AssociationIdx.PARENT],
        ParentId = lines[(int)AssociationIdx.PARENTID],
        ChildGroup = lines[(int)AssociationIdx.CHILD],
        ChildId = lines[(int)AssociationIdx.CHILDID]
    }).ToList();

foreach (var items in record)
    Associations.Add(items);
*/

                //var lines = File.ReadLines(filePath).Select(
                //    line => line.RemoveCharacters("\"").Split(',')).
                //    Where(data =>
                //              {
                //                  return GetAll ? true : data[(int)AssociationIdx.PARENTID] == id;
                //              }).Select( 
                //        items => new Association()  // TODO add logic to filter by ID
                //                     {
                //                         ParentGroup = items[(int) AssociationIdx.PARENT],
                //                         ParentId = items[(int) AssociationIdx.PARENTID],
                //                         ChildGroup = items[(int) AssociationIdx.CHILD],
                //                         ChildId = items[(int) AssociationIdx.CHILDID]
                //                         //Group = items[(int) AssociationIdx.GROUP]
                //                     });


/* WORKING
var record = File.ReadLines(filePath).Select(
    lines => lines.RemoveCharacters("\"").Split(',')).
    Where(line =>
              {
                  return GetAll
                             ? true
                             : Ids.FindIndex(val_ => val_ == line[(int)AssociationIdx.PARENTID]) >= 0;
              })
             .Select(
                    lines => new Association()  // TODO add logic to filter by ID
                     {
                         ParentGroup = lines[(int)AssociationIdx.PARENT],
                         ParentId = lines[(int)AssociationIdx.PARENTID],
                         ChildGroup = lines[(int)AssociationIdx.CHILD],
                         ChildId = lines[(int)AssociationIdx.CHILDID]
                     }).ToList();

foreach (var items in record)
    Associations.Add(items);


var data = record.Select(lines => lines)
    .Where(lines =>
               {
                   if (isParentGroup.HasValue && isParentGroup.Value)
                       matchParentGroup = lines.ParentGroup == _parentgroup;

                   if (isChildGroup.HasValue & isChildGroup.Value)
                       matchChildGroup = lines.ChildGroup  == _childgroup;

                   return matchParentGroup && matchChildGroup;

               }).ToList();

foreach (var items in data)
    Associations.Add(items);

 
var record = File.ReadLines(filePath).Select(
    lines => lines.RemoveCharacters("\"").Split(','))
    .Where( line =>
                {
                    return GetAll
                               ? true
                               : Ids.FindIndex(val_ => val_ == line[(int) AssociationIdx.PARENTID]) >= 0;
                })
                .Where(line =>
                           {
                               if (isParentGroup.HasValue &&isParentGroup.Value )
                                  matchParentGroup = line[(int)AssociationIdx.PARENT] == _parentgroup;

                               if (isChildGroup.HasValue &isChildGroup.Value )
                                  matchChildGroup = line[(int)AssociationIdx.CHILD ] == _childgroup ;

                               return matchParentGroup && matchChildGroup;

                           })
             .Select( line =>
                    if (isParentGroup.HasValue &&isParentGroup.Value )
                        matchParentGroup = line[(int)AssociationIdx.PARENT] == _parentgroup;

                    if (isChildGroup.HasValue &isChildGroup.Value )
                        matchChildGroup = line[(int)AssociationIdx.CHILD ] == _childgroup ;

                    if (matchParentGroup && matchChildGroup)
                        lines => new Association()
                                     {
                                         ParentGroup = lines[(int) AssociationIdx.PARENT],
                                         ParentId = lines[(int) AssociationIdx.PARENTID],
                                         ChildGroup = lines[(int) AssociationIdx.CHILD],
                                         ChildId = lines[(int) AssociationIdx.CHILDID]
                                     };
                     ).ToList() ;
*/





//var record = File.ReadLines(filePath).Select(
//    lines => lines.RemoveCharacters("\"").Split(',')).
//    Where(line =>
//              {
//                  return GetAll
//                             ? true
//                             : Ids.FindIndex(val_ => val_ == line[(int) AssociationIdx.PARENTID]) >= 0;
//              })
//             .Select( 
//                    lines => new Association()  // TODO add logic to filter by ID
//                     {
//                         ParentGroup = lines[(int)AssociationIdx.PARENT],
//                         ParentId = lines[(int)AssociationIdx.PARENTID],
//                         ChildGroup = lines[(int)AssociationIdx.CHILD],
//                         ChildId = lines[(int)AssociationIdx.CHILDID]
//                     }).ToList() ;
