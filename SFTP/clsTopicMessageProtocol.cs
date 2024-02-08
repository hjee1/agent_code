using System;
using Confluent.Kafka;
using Newtonsoft.Json;
using System.Threading.Tasks;


namespace SFTP
{

    public class KafkaProtocol
    {
        private string _bootstrapServers;

        public KafkaProtocol(string bootstrapServers)
        {
            _bootstrapServers = bootstrapServers;
        }

        public bool UploadMessageToKafka(string topic, string key, string data, string bootstrapServers)
        {
            try
            {
                var config = new ProducerConfig
                {
                    BootstrapServers = bootstrapServers
                };

                using (var kafkaProducer = new ProducerBuilder<string, string>(config).Build())
                {
                    // Define a variable to hold the delivery result
                    DeliveryResult<string, string> deliveryResult = null;

                    // Produce the message synchronously
                    kafkaProducer.Produce(topic, new Message<string, string> { Key = key, Value = data }, report =>
                    {
                        deliveryResult = report;
                    });

                    // Wait for the message to be acknowledged by the broker
                    kafkaProducer.Flush(TimeSpan.FromSeconds(10));

                    // Check if the message was successfully delivered
                    if (deliveryResult != null && deliveryResult.Status == PersistenceStatus.Persisted)
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
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error uploading message to Kafka: {ex.Message}");
                return false;
            }
        }

    }


}