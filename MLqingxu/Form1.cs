using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.ML;
using Microsoft.ML.Data;

namespace MLqingxu
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// 训练文件路径
        /// </summary>
        private string _filepath = Path.Combine(Environment
                .CurrentDirectory, "qingxudata.txt");
        /// <summary>
        /// ML.NET 操作的起点
        /// </summary>
        private MLContext _mlContext;

        private DataOperationsCatalog.TrainTestData _qingxuDataView;

        private ITransformer _transformer;


        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        private void LoadData()
        {
            _mlContext = new MLContext();
            //加载数据
            IDataView dataView = _mlContext.Data
                .LoadFromTextFile<qingxubase>(_filepath
                    , hasHeader: false);
            //拆分数据集以进行模型训练和测试
            _qingxuDataView = _mlContext.Data
                .TrainTestSplit(dataView, testFraction: 0.2);
        }

        /// <summary>
        /// 生成和定型模型
        /// </summary>
        private void CreateModel()
        {
            //提取并转换数据
            var estimator = _mlContext.Transforms.Text
                .FeaturizeText(outputColumnName: "Features",
                    inputColumnName: nameof(qingxubase.qingxutext))
                //添加学习算法
                .Append(_mlContext.BinaryClassification
                    .Trainers.SdcaLogisticRegression(labelColumnName: "Label"
                        , featureColumnName: "Features"));
            //定型模型
            _transformer = estimator.Fit(_qingxuDataView.TrainSet);
        }

        /// <summary>
        /// 评估模型
        /// </summary>
        /// <returns></returns>
        private CalibratedBinaryClassificationMetrics EstimateModel()
        {
            //加载测试数据集
            IDataView predictions = _transformer.Transform(
                _qingxuDataView.TestSet);
            //创建 BinaryClassification 计算器。
            CalibratedBinaryClassificationMetrics metrics =
                _mlContext.BinaryClassification.Evaluate(predictions
                    , "Label");
            return metrics;
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            LoadData();
            tbMsg.AppendText("加载数据完成！\r\n");

            CreateModel();
            tbMsg.AppendText("生成和定型模型完成!\r\n");

            var metrics = EstimateModel();
            tbMsg.AppendText($"准确:{metrics.Accuracy:P2}\r\n");
            tbMsg.AppendText($"曲线下面积: {metrics.AreaUnderRocCurve:P2}\r\n");
            tbMsg.AppendText($"分数: {metrics.F1Score:P2}\r\n");
        }

        private void btnCs_Click(object sender, EventArgs e)
        {
            //创建测试数据的单个注释
            PredictionEngine<qingxubase,qingxufenxi> predictionFunction
                = _mlContext.Model.CreatePredictionEngine
                    <qingxubase, qingxufenxi>(_transformer);
            
            //根据文本框输入的文本生成要预测数据
            qingxubase data = new qingxubase();
            data.qingxutext = tbInput.Text;
            
            //结合测试数据和预测进行报告并显示结果
            tbMsg.AppendText("\r\n根据输入预测\r\n");
            var result = predictionFunction
                .Predict(data);
            string str = $"情绪: {result.qingxutext}|" +
                         $"预测: {(Convert.ToBoolean(result.isyuce) ? "积极" : "消极")}|" +
                         $"概率: {result.Gailv}|分数:{result.Score}";
            tbMsg.AppendText(str + "\r\n");
        }

        private void btnyc_Click(object sender, EventArgs e)
        {
            //创建批处理测试数据
            IEnumerable<qingxubase> qingxubases = new[]
            {
                new qingxubase
                {
                    qingxutext = "太开心了，明天是个大晴天"
                },
                new qingxubase
                {
                    qingxutext = "下雨了，又去不成演唱会了"
                },
                new qingxubase
                {
                    qingxutext = "你就不能好好说话吗"
                }
            };

  
            //根据测试数据预测情绪
            IDataView batchComments = _mlContext.Data
                .LoadFromEnumerable(qingxubases);

            IDataView predictions = _transformer
                .Transform(batchComments);

            //判断是积极还是消极的情绪
            IEnumerable<qingxufenxi> results =
                _mlContext.Data.CreateEnumerable<qingxufenxi>
                    (predictions, reuseRowObject: false);

            //显示预测结果
            tbMsg.AppendText("\r\n显示预测结果\r\n");
            foreach (qingxufenxi item in results)
            {
                string str = $"情绪: {item.qingxutext} " +
                             $"| 预测: {(Convert.ToBoolean(item.isyuce) ? "积极" : "消极")} " +
                             $"| 概率: {item.Gailv} " +
                             $"| 分数：{item.Score}";
                tbMsg.AppendText(str + "\r\n");
            }
        }
    }
}
