using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Data.Objects.Shared;
using Data.Objects;
using Data.DataAccess;

namespace SaleEvent
{
    public partial class SalesEvent : Form
    {
        private string parentid_ = "00000000000000085967_00000001220429793929_03490";
        private NamesDo names;
        private AssociationsDo associations;
        private ContactsDo contacts;
        private ContactsDo addresses;
        private ContactsDo phones;
        private ContactsDo emails;
        private string _francheseeId = "00000000000000080533_00000001219860847215_00001";
        private string _clientId;


        private List<Association> ClientAssociation;

        public SalesEvent()
        {
            InitializeComponent();
        }

        private void SalesEvent_Load(object sender, EventArgs e)
        {
            associations = new AssociationsDo();
        }
        private void LoadClientData()
        {
            associations.ParentId  = "00000000000000080533_00000001219860847215_00001";
            associations.ParentGroup = "FRANCHESEE"; // parent
            associations.ChildGroup = "CLIENT";
            //associations = new AssociationsDo(parentgroup, parentid, childgroup, "parent");
            ClientAssociation = associations.LoadData();
        }
        private void LoadClientContactData()
        {
            associations.ParentId = ClientAssociation.FindLast(element => element.ParentId == _francheseeId).ChildId;
            associations.ParentGroup = "CLIENT"; // parent            
            associations.ChildGroup = "CONTACT";
            associations.IDType = (int) AssociationIdx.PARENTID;
            //associations = new AssociationsDo(parentgroup, parentid, childgroup, "parent");
            List<Association> LoadClientContactData = associations.LoadData();
        }
    }
}
    