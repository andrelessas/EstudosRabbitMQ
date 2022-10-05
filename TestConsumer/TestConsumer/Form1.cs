using System.Data.Common;
using System.Threading.Channels;
using System;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using TestConsumer.Entities;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Linq.Expressions;

namespace TestConsumer
{
    public partial class Form1 : Form
    {
        private string _queue;
        private IConnection _connection;
        private IModel _channel;

        delegate void SetDataGridCallBack(List<Product> listObject);

        public Form1()
        {
            InitializeComponent();
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var consumer = new EventingBasicConsumer(_channel);
                consumer.Received += async (sender, eventArgs) =>
                {
                    try
                    {
                        var productByte = eventArgs.Body.ToArray();
                        var productJson = Encoding.UTF8.GetString(productByte);
                        var productList = new List<Product>();
                        try
                        {
                            productList = JsonConvert.DeserializeObject<List<Product>>(productJson);

                        }
                        catch
                        {
                            var product = JsonConvert.DeserializeObject<Product>(productJson);
                            productList.Add(product);
                        }

                        SetDataGridCall(productList);
                        _channel.BasicAck(eventArgs.DeliveryTag, false);
                    }catch
                    {}
                };

            _channel.BasicConsume(_queue, false, consumer);           
        }

        private void SetDataGridCall(List<Product> listObject)
        {
            if(InvokeRequired)
            {
                SetDataGridCallBack dataGrid = new SetDataGridCallBack(SetDataGridCall);
                this.Invoke(dataGrid, new object[] {listObject});
            }else
                dataGridView1.DataSource = listObject;
        
        }

        private void ConnectRabbitMQ()
        {

            var factory = new ConnectionFactory
            {
                HostName = txtHost.Text,
                UserName = txtUser.Text,
                Password = txtPassWord.Text
            };

            if (_connection != null)
                _connection.Close();
            
            if (_channel != null)
                _channel.Close();
            
            _queue = txtQueue.Text;            
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.QueueDeclare(
                queue: _queue,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            ConnectRabbitMQ();
            backgroundWorker1.RunWorkerAsync();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
        }
    }
}