using System;
using Confluent.Kafka;
using Newtonsoft.Json;
using System.Threading.Tasks;


namespace SFTP
{

    public class KafkaProtocol
    {
        private IProducer<string, string> kafkaProducer;

        public KafkaProtocol(string bootstrapServers)
        {
            var config = new ProducerConfig
            {
                BootstrapServers = bootstrapServers
            };

            kafkaProducer = new ProducerBuilder<string, string>(config).Build();
        }





        // Function to upload a topic message to Kafka
        public async Task<bool> UploadMessageToKafkaAsync(string topic, string key, object data)
        {
            try
            {
                // Convert data to JSON string
                var messageValue = JsonConvert.SerializeObject(data);

                // Produce the message asynchronously
                var deliveryResult = await kafkaProducer.ProduceAsync(topic, new Message<string, string> { Key = key, Value = messageValue });

                // Wait for the message to be acknowledged by the broker.
                // This is optional and depends on your requirements.
                kafkaProducer.Flush(TimeSpan.FromSeconds(10));

                // Check if the message was successfully delivered
                if (deliveryResult.Status == PersistenceStatus.Persisted)
                {
                    Console.WriteLine($"Message delivered to {deliveryResult.TopicPartitionOffset}");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Failed to deliver message to Kafka");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error uploading message to Kafka: {ex.Message}");
                return false;
            }
        }





    }

}