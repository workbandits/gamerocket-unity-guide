using System;

namespace GameRocket
{
	public class Environment
	{
		public static Environment DEVELOPMENT = new Environment("development");
        public static Environment PRODUCTION = new Environment("production");

        private String environmentName;

        public String GatewayURL
        {
            get
            {
                switch (environmentName)
                {
                    case "development":
                        return DevelopmentUrl();
                    case "production":
                        return "https://api.gamerocket.io:443/1";
                    default:
                        throw new Exception("Unsupported environment");
                }
            }
        }

        private Environment(String name)
        {
            environmentName = name;
        }

        private static String DevelopmentUrl()
        {
            var host = System.Environment.GetEnvironmentVariable("GATEWAY_HOST") ?? "192.168.0.18";
            var port = System.Environment.GetEnvironmentVariable("GATEWAY_PORT") ?? "8280";

            return String.Format("http://{0}:{1}/1", host, port);
        }
	}
}

