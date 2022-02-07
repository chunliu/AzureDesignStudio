using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureDesignStudio.Core.Models
{
    public class Region
    {
        public Region(string name) : this(name, name)
        {

        }
        public Region(string name, string value)
        {
            Name = name;
            Value = value;
        }
        public string Name { get; set; }
        public string Value { get; set; }
    }
    public static class AzureRegions
    {
        public static IReadOnlyCollection<Region> AllRegions = new List<Region>()
        {
            #region Americas
            new Region("West US", "westus"),
            new Region("West US 2", "westus2"),
            new Region("West US 3", "westus3"),
            new Region("Central US", "centralus"),
            new Region("East US", "eastus"),
            new Region("East US 2", "eastus2"),
            new Region("North Central US", "northcentralus"),
            new Region("South Central US", "southcentralus"),
            new Region("West Central US", "westcentralus"),
            new Region("Canada Central", "canadacentral"),
            new Region("Canada East", "canadaeast"),
            new Region("Brazil South", "brazilsouth"),
            #endregion

            #region Europe
            new Region("North Europe", "northeurope"),
            new Region("West Europe", "westeurope"),
            new Region("UK South", "uksouth"),
            new Region("UK West", "ukwest"),
            new Region("France Central", "Francecentral"),
            new Region("France South", "francesouth"),
            new Region("Switzerland North", "switzerlandnorth"),
            new Region("Switzerland West", "switzerlandwest"),
            new Region("Germany North", "germanynorth"),
            new Region("Germany West Central", "germanywestcentral"),
            new Region("Norway West", "norwaywest"),
            new Region("Norway East", "norwayeast"),
            #endregion

            #region Asia
            new Region("East Asia", "eastasia"),
            new Region("Southeast Asia", "southeastasia"),
            new Region("Japan East", "japaneast"),
            new Region("Japan West", "japanwest"),
            new Region("Australia East", "australiaeast"),
            new Region("Australia Southeast", "australiasoutheast"),
            new Region("Australia Central", "australiacentral"),
            new Region("Australia Central2", "australiacentral2"),
            new Region("Central India", "centralindia"),
            new Region("South India", "southindia"),
            new Region("West India", "westindia"),
            new Region("Korea South", "koreasouth"),
            new Region("Korea Central", "koreacentral"),
            #endregion

            #region Middle East and Africa
            new Region("UAE Central", "uaecentral"),
            new Region("UAE North", "uaenorth"),
            new Region("South Africa North", "southafricanorth"),
            new Region("South Africa West", "southafricawest"),
            #endregion

            #region China
            new Region("China North", "chinanorth"),
            new Region("China East", "chinaeast"),
            new Region("China North 2", "chinanorth2"),
            new Region("China East 2", "chinaeast2"),
            #endregion

            #region German
            new Region("Germany Central", "germanycentral"),
            new Region("Germany Northeast", "germanynortheast"),
            #endregion
        };
    }
}
