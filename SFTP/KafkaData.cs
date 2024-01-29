using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;
using SFTP;

public class KafkaData
{
    public string SparkConfigAppName { get; set; }
    public string SparkConfigSetMaster { get; set; }
    public string objectStoragePath { get; set; }
    public string sourceType { get; set; }
    public string fileName { get; set; }
    public string fileExtension { get; set; }
    public bool csvHeader { get; set; }
    public string csvCustomHeader { get; set; }
    public string csvDelimiter { get; set; }
    public string jsonParseSelectedKey { get; set; }
    public string targetType { get; set; }
    public string targetCatalog { get; set; }
    public string targetDatabase { get; set; }
    public string targetTable { get; set; }
    public string startDateTime { get; set; }
    
    public List<SparkConfigItem> SparkConfigs { get; set; }
}
