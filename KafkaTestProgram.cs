
using System;
using System.Threading.Tasks;
using Confluent.Kafka;

namespace KafkaTest
{
	static internal class KafkaTestProgram
	{
		static KafkaTestProgram()
		{
		}

		static internal async Task Start(string[] args)
		{
			// var config = new ProducerConfig
			// {
			// 	BootstrapServers = "kafka:9092",
			// 	MessageTimeoutMs = 30000.
			//  ApiVersionRequest = false,
			// };

			// // If serializers are not specified, default serializers from
			// // `Confluent.Kafka.Serializers` will be automatically used where
			// // available. Note: by default strings are encoded as UTF8.
			// using (var p = new ProducerBuilder<Null, string>(config).Build())
			// {
			// 	try
			// 	{
			// 		var dr = await p.ProduceAsync("test-topic", new Message<Null, string> { Value = "tes2t" });
			// 		Console.WriteLine($"Delivered '{dr.Value}' to '{dr.TopicPartitionOffset}'");
			// 	}
			// 	catch (ProduceException<Null, string> e)
			// 	{
			// 		Console.WriteLine($"Delivery failed: {e.Error.Reason}");
			// 	}
			// }
			var config = new ConsumerConfig
			{
				BootstrapServers = "kafka:9092",
                AutoOffsetReset = AutoOffsetReset.Earliest,
				GroupId = "hz",
                EnableAutoCommit = false,
                ApiVersionRequest = false,
			};

			// If serializers are not specified, default serializers from
			// `Confluent.Kafka.Serializers` will be automatically used where
			// available. Note: by default strings are encoded as UTF8.
			using (var c = new ConsumerBuilder<Null, string>(config).Build())
			{
				try
				{
					c.Subscribe("test-topic");
					var o = c.Position(new TopicPartition("test-topic", new Partition(0)));
					var a = c.GetWatermarkOffsets(new TopicPartition("test-topic", new Partition(0)));
					var cr = c.Consume();
				}
				catch (ConsumeException e)
				{
				}
			}
		}
	}
}