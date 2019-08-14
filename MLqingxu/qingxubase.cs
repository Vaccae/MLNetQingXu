using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML.Data;

namespace MLqingxu
{
    public class qingxubase
    {
        /// <summary>
        /// 情绪文本
        /// </summary>
        [LoadColumn(0)]
        public string qingxutext;
        /// <summary>
        /// 判断是好情绪还是坏情绪
        /// </summary>
        [LoadColumn(1), ColumnName("Label")]
        public bool isgoodorbad;
    }
}
