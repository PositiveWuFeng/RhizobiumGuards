using System.Collections;
using System.Collections.Generic;
using Game.Base;
using OfficeOpenXml;
using UnityEngine;

namespace Excel
{
    public class DataManager : MonoBehaviour
    {
        public GameObject data;

        [ContextMenu("WritePropertyData")]
        public void WriteItemData()
        {
            Property tempData = data.GetComponent<Property>();

            for (int i = 0; i < 5; i++)
            {
                tempData.HP = float.Parse(ExcelTool.ReadExcel(1, i + 2, 2));
                tempData.power = float.Parse(ExcelTool.ReadExcel(1, i + 2, 3));
                tempData.attackRange = float.Parse(ExcelTool.ReadExcel(1, i + 2, 4));
                tempData.attackSpeed = float.Parse(ExcelTool.ReadExcel(1, i + 2, 5));
                tempData.moveSpeed = float.Parse(ExcelTool.ReadExcel(1, i + 2, 6));
                tempData.level = int.Parse(ExcelTool.ReadExcel(1, i + 2, 7));
            }
        }
    }
}
