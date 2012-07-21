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
        /*__________________________________________________________________________________________*/
        public List<Association> GetAllAssociationsByChildGroup(string childgroup)
        {
            var results = Associations.FindAll(items => items.ChildGroup == childgroup);
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
