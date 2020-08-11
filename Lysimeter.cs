using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace LLogger
	{
	class Environment
		{
		//public double humidity { get; set; }
		//public double temperature { get; set; }
		public double radiation { get; set; }
		//public double testWt { get; set; }

		public Queue<double> temperatures;
		public Queue<double> humidities;
		public Queue<double> temperatures2;

		string rtdTemperatures;


		System.IO.Ports.SerialPort rs485;
		public Environment(System.IO.Ports.SerialPort _rs485)
			{
			rs485 = _rs485;
			temperatures = new Queue<double>();
			humidities = new Queue<double>();
			temperatures2 = new Queue<double>();
			}
		public double getT2()
			{
			double value = mV(32, 6, 10);
			return (value * 100) - 40;
			}
		public void getEnvironment()
			{
			double[] env = new double[4];

			//sendCmd("%2020040A80" + "\r");	// set the input range

			for (int ch = 0; ch < 3; ch++)
				env[ch] = mV(32, ch, 10);
			env[3] = mV(32, 6, 10);

			humidities.Enqueue(env[0] * 100); // humidity in %
			if (humidities.Count > 15)
				humidities.Dequeue();

			temperatures.Enqueue((env[1] * 100) - 40); // volts from 0 to 1 temperature range from -40 to +60
			if (temperatures.Count > 15)
				temperatures.Dequeue();
			temperatures2.Enqueue((env[3] * 100) - 40); // volts from 0 to 1 temperature range from -40 to +60
			if (temperatures2.Count > 15)
				temperatures2.Dequeue();

			// radiation calibration to be done yet TODO
			radiation = env[2];

			// test weight
			//sendCmd("%2020000A80" + "\r");	// set the input range

			//env[3] = mV(32, 5, 10);
			//if (env[3] < 1.0)
			//	env[3] *= 1000;
			//testWt = 4.9925 * env[3] - 0.9885;  // calibration for test weight

			// get temperatures from 6 RTD
			rtdTemperatures = getRTD();


			}
		private bool sendCmd(string cmd)
			{
			//  %AANNTTCCFF  2020040A80 for +/1 1V
			//  %AANNTTCCFF  2020000A80 for +/1 15mV
			// change the range of the analog input

			string reply = "";
			do
				{
				rs485.Write(cmd);
				Thread.Sleep(30);
				reply = rs485.ReadExisting();
				}
			while (!(reply.Length > 0 && reply[0] == '!'));
			Thread.Sleep(1000);
			return true;
			}

		private double mV(uint module, int channel, int nReadings)
			{
			List<double> values = new List<double>();
			string cmd = "#" + module.ToString("X").PadLeft(2, '0') + channel.ToString() + "\r";
			for (int i = 0; i < nReadings; i++)
				{
				rs485.Write(cmd);
				Thread.Sleep(30);
				string reply = rs485.ReadExisting();
				if (reply.Length > 0 && reply[0] == '>')
					{
					string sval = reply.Substring(1, reply.Length - 2);
					values.Add(Convert.ToDouble(sval));
					}
				}
			if (values.Count < nReadings / 2) return 0.0;
			return Median(values);

			}
		static double Median(List<double> Numbers)
			{
			Numbers.Sort();
			int size = Numbers.Count;
			int mid = size / 2;
			double median = (size % 2 != 0) ? Numbers[mid] : (Numbers[mid] + Numbers[mid - 1]) / 2.0;
			return median;
			}

		public double humidity()
			{
			return humidities.Average();
			}
		public double temperature()
			{
			return temperatures.Average();
			}
		public double temperature2()
			{
			return temperatures2.Average();
			}

		private string getRTD()
			{
			string temps = "";
			byte[] message = new byte[8] { 33, 3, 0, 1, 0, 6, 147, 104 };  // message for addr 1, 6 channels
			byte[] response = new byte[17];			// buffer for response
			short[] values = new short[6];
			try
				{
				// clear buffers
				rs485.DiscardOutBuffer();
				rs485.DiscardInBuffer();
				// send message to get temperatures
				rs485.Write(message, 0, message.Length);

				Thread.Sleep(100);
				// read reply
				rs485.Read(response, 0, response.Length);
				// convert reply
				if (response.Length != 17) return "";
				for (int i = 0; i < values.Length; i++)
					{
					values[i] = response[2 * i + 3];
					values[i] <<= 8;
					values[i] += response[2 * i + 4];
					temps += "," + (values[i] / 10.0).ToString("F1");
					}
				return temps;
				}
			catch (Exception ex)
				{
				return ex.Message;
				}

			}

		public string envString()
			{
			string outputLine = humidity().ToString("F2") + "," + temperature().ToString("F2")
				+ "," + radiation.ToString("F4") + "," + temperature2().ToString("F2") + rtdTemperatures;
			return outputLine;
			}
		}

	class Thermocouple
		{
		//	public double [] temperatures;
		uint address;

		public Queue<double>[] temperatures;

		public double refTemp()
			{
			return tcRef(address, 10);
			}

		System.IO.Ports.SerialPort rs485;
		public Thermocouple(System.IO.Ports.SerialPort _rs485, uint _address)
			{
			rs485 = _rs485;
			address = _address;
			temperatures = new Queue<double>[9];		// 8 channels and reference temperature
			for (int i = 0; i < 9; i++)
				temperatures[i] = new Queue<double>();
			}
		public void getTemperatures()
			{
			for (int ch = 0; ch < 8; ch++)
				{
				temperatures[ch].Enqueue(tc(address, ch, 10));
				temperatures[ch].Enqueue(0.0);
				if (temperatures[ch].Count > 15)
					temperatures[ch].Dequeue();
				}
			// get reference temperature
			temperatures[8].Enqueue(tcRef(address, 10));
			temperatures[8].Enqueue(0.0);
			}

		private double tc(uint module, int channel, int nReadings)
			{
			List<double> values = new List<double>();
			string cmd = "#" + module.ToString("X").PadLeft(2, '0') + channel.ToString() + "\r";
			for (int i = 0; i < nReadings; i++)
				{
				rs485.Write(cmd);
				Thread.Sleep(30);
				string reply = rs485.ReadExisting();
				if (reply.Length > 0 && reply[0] == '>')
					{
					string sval = reply.Substring(1, reply.Length - 2);
					values.Add(Convert.ToDouble(sval));
					}
				}
			if (values.Count < nReadings / 2) return 0.0;
			return Median(values);

			}
		private double tcRef(uint module, int nReadings)
			{
			List<double> values = new List<double>();
			string cmd = "$" + module.ToString("X").PadLeft(2, '0') + "3" + "\r";
			for (int i = 0; i < nReadings; i++)
				{
				rs485.Write(cmd);
				Thread.Sleep(30);
				string reply = rs485.ReadExisting();
				if (reply.Length > 0 && reply[0] == '>')
					{
					string sval = reply.Substring(1, reply.Length - 2);
					try
						{
						values.Add(Convert.ToDouble(sval));
						}
					catch (Exception)
						{
						values.Add(0);
						}
					}
				}
			if (values.Count < nReadings / 2) return 0.0;
			return Median(values);

			}
		static double Median(List<double> Numbers)
			{
			Numbers.Sort();
			int size = Numbers.Count;
			int mid = size / 2;
			double median = (size % 2 != 0) ? Numbers[mid] : (Numbers[mid] + Numbers[mid - 1]) / 2.0;
			return median;
			}

		public string tempString()
			{
			string outputLine = "";
			for (int i = 0; i < 8; i++)
				{
				outputLine += "," + temperatures[i].Average().ToString("F2");
				}
			outputLine += "," + temperatures[8].Average().ToString("F2"); // reference temperature
			return outputLine;
			}


		}

	class Pot
		{
		public int potNo { get; set; }
		public int tableNo { get; set; }
		System.IO.Ports.SerialPort rs485;

		public double slope { get; set; }
		public double intercept { get; set; }
		public double targetWt { get; set; }
		public double maximumWt { get; set; }

		public double weight { get; set; }
		public Queue<double> weights;

		public Pot(int _tableNo, int _potNo, System.IO.Ports.SerialPort _rs485)
			{
			tableNo = _tableNo;
			potNo = _potNo;
			rs485 = _rs485;
			weight = 0.0;
			weights = new Queue<double>();
			}

		public bool water()
			{
			return setChannel("01");		// 01 sets the channel to on
			}
		public bool stopWatering()
			{
			return setChannel("00");		// 00 sets the channel to off
			}
		public bool isWatering()
			{
			return getChannel();
			}

		public void setWeight(double mV) // get the mV reading and add to the weights
			{
			// current weight is the moving average of the last 15 weights, unless there has been a watering
			double wtNow = slope * mV + intercept;
			if (wtNow < 0.0) wtNow = 0.0;	// for empty tables
			// if a watering has occurred, reset the Queue
			if (weights.Count > 0 && wtNow - weights.Last() > 150)
				weights.Clear();

			weights.Enqueue(wtNow);
			if (weights.Count > 15)
				weights.Dequeue();
			weight = weights.Average();

			}

		public double weightNow()		// instantaneous wt
			{
			double mV = -100.0;
			int attempts = 0;
			do
				{
				mV = getMv();
				attempts++;
				}
			while (mV < -10 && attempts < 100);
			return (slope * mV + intercept);
			}

		public double stableWeight()		// stable wt
			{
			// get a stable mv and convert to weight. Get 10 consecutive readings within 0.001 mV
			double mVtarget = 0.0;
			int maxReadings = 100;		// if a reading cannot be found in 100 quit
			int nReadings = 0;

			for (int i = 0; i < maxReadings; i++)
				{
				double mV = getMv();
				if (mV < -10) continue;
				if (Math.Abs(mV - mVtarget) < 0.001)		// reading within 0.001
					{
					nReadings++;
					}
				else
					{
					mVtarget = mV;
					nReadings = 0;
					}
				if (nReadings > 10)
					break;
				//Thread.Sleep(30);
				}
			return Math.Max((slope * mVtarget + intercept), 0.0);

			}


		// low level calls to the devices
		private bool getChannel()
			{
			// returns if the solenoid is open. Command returns all channels in 2 hex numbers
			int addr = tableNo + 16;  //address of the digital output is tableno + 16
			string cmd = "$" + addr.ToString("X").PadLeft(2, '0') + "6\r";
			string reply = "";
			do
				{
				rs485.Write(cmd);
				Thread.Sleep(30);
				reply = rs485.ReadExisting();
				}
			while (!(reply.Length > 0 && reply[0] == '!'));
			int value = int.Parse(reply.Substring(3, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
			int ch = value & (int)Math.Pow(2, potNo);

			return ch > 0;
			}
		private bool setChannel(string value)
			{
			int addr = tableNo + 16;  //address of the digital output is tableno + 16
			int offset = 0;
			// set the digital channel of the i-7045 to the value (0,1)
			string bank = "A";
			if (potNo > 7)	// upper bank of 8
				{
				offset = 8;
				bank = "B";
				}
			string reply = "";
			string cmd = "#" + addr.ToString("X").PadLeft(2, '0') + bank + (potNo - offset).ToString() + value + "\r";
			do
				{
				rs485.Write(cmd);
				Thread.Sleep(30);
				reply = rs485.ReadExisting();
				}
			while (!(reply.Length > 0 && reply[0] == '>'));

			if (reply.Length > 0)
				if (reply[0] == '>')
					return true;
			return false;
			}
		private double getMv()
			{
			double mV = -100;
			if (!rs485.IsOpen)
				return mV;
			string cmd = "#" + tableNo.ToString("X").PadLeft(2, '0') + potNo.ToString() + "\r";
			rs485.Write(cmd);
			Thread.Sleep(30);
			string reply = rs485.ReadExisting();
			int len = reply.Length;
			if (len == 9 && reply[0] == '>')
				{
				try
					{
					mV = Convert.ToDouble(reply.Substring(1, 7));
					}
				catch (Exception)
					{
					mV = -100.0;
					}
				}
			return mV;
			}
		public string potString()
			{
			return (tableNo + 1).ToString() + ", " + (potNo + 1).ToString();
			}
		}

	class Table
		{
		int nPots;
		public List<Pot> pots;
		public int tableNo { get; set; }
		private List<double> cjcTemperatures;
		System.IO.Ports.SerialPort rs485;

		public Table(int _nPots, int _tableNo, System.IO.Ports.SerialPort _rs485)
			{
			tableNo = _tableNo;
			nPots = _nPots;
			rs485 = _rs485;
			pots = new List<Pot>(nPots);
			for (int potNo = 0; potNo < nPots; potNo++)
				pots.Add(new Pot(tableNo, potNo, rs485));
			cjcTemperatures = new List<double>();
			}
		public void updateCJC()
			{
			// read the cjc temperature and add it to the list;
			// needs a rewrite!
			//sendCmd("$003" + "\r");	// internal temp
			cjcTemperatures.Add(getCurrentCJC());
			}

		public double getCJC()
			{
			// get the average temperature and return it - clear the list
			double cjcTemperature = 0.0;
			if (cjcTemperatures.Count > 0)
				cjcTemperature = cjcTemperatures.Average();
			cjcTemperatures.Clear();
			return cjcTemperature;
			}
		public double getCurrentCJC()
			{
			double temperature = 0.0;
			string cmd = "$" + tableNo.ToString("X").PadLeft(2, '0') + "3" + "\r";
			rs485.Write(cmd);
			Thread.Sleep(30);
			string reply = rs485.ReadExisting();
			if (reply.Length > 2 && reply[0] == '>')
				{
				string sval = reply.Substring(1, reply.Length - 2);
				try
					{
					temperature = Convert.ToDouble(sval);
					}
				catch (Exception)
					{
					rs485.ReadExisting();
					}
				}
			return temperature;
			}

		public void weigh()
			{
			// weigh all the pots on this table
			// get the stable mV of all pots
			double[] mVPot = mVstable();
			// allocate to pots
			for (int i = 0; i < nPots; i++)
				pots[i].setWeight(mVPot[i]);
			}

		public double[] mVstable()		// stable wt
			{
			int nGood = 5;
			// get a stable mv and convert to weight. Get nGood consecutive readings within 0.001 mV
			double[] mVtarget = new double[nPots];
			int maxReadings = 100;		// if a reading cannot be found in 100 quit
			int[] nReadings = new int[nPots];

			for (int i = 0; i < maxReadings; i++)
				{
				double[] mV = getMv();
				for (int potNo = 0; potNo < nPots; potNo++)
					{
					if (mV[potNo] < -10 || nReadings[potNo] == nGood) continue;
					if (Math.Abs(mV[potNo] - mVtarget[potNo]) < 0.001)		// reading within +/- 0.001
						{
						nReadings[potNo]++;
						}
					else
						{
						mVtarget[potNo] = mV[potNo];
						nReadings[potNo] = 0;
						}
					}
				// check to see if all pots have a stable weight
				bool stable = true;
				for (int j = 0; j < nPots; j++)
					if (nReadings[j] < nGood)
						stable = false;
				if (stable)
					break;
				Thread.Sleep(30);
				}
			return mVtarget;

			}
		private double[] getMv()
			{
			double[] mV = new double[nPots]; for (int i = 0; i < 8; i++) mV[i] = -100.0;
			if (!rs485.IsOpen)
				return mV;
			string cmd = "#" + tableNo.ToString("X").PadLeft(2, '0') + "\r";
			rs485.Write(cmd);
			Thread.Sleep(30);
			// >+05.123+04.153+07.234-02.356+10.000-05.133+02.345+08.234
			string reply = rs485.ReadExisting();
			int len = reply.Length;
			if (len == 58 && reply[0] == '>')
				{
				for (int i = 0; i < nPots; i++)
					{
					try
						{
						mV[i] = Convert.ToDouble(reply.Substring(1 + i * 7, 7));
						}
					catch (Exception)
						{
						mV[i] = -100.0;
						}
					}
				}
			return mV;
			}

		}

	class LPad
		{
		int nTables;
		int nThermocouples;
		public List<Table> tables;
		public Environment environment;

		public List<Thermocouple> thermocouples;
		System.IO.Ports.SerialPort rs485;

		public LPad(int _nTables, int _nPots, int _nThermocouples, System.IO.Ports.SerialPort _rs485)
			{
			nTables = _nTables;
			nThermocouples = _nThermocouples;
			environment = new Environment(_rs485);

			thermocouples = new List<Thermocouple>(nThermocouples);
			uint addr = 34;
			for (uint i = 0; i < nThermocouples; i++)
				{
				thermocouples.Add(new Thermocouple(_rs485, addr + i));
				}

			rs485 = _rs485;
			tables = new List<Table>(nTables);
			for (int tableNo = 0; tableNo < nTables; tableNo++)
				{
				tables.Add(new Table(_nPots, tableNo, rs485));
				}
			}

		// check devices are available
		public string CheckDevices()
			{
			int weighDev = 0;
			int waterDev = 0;
			string devices = "";
			for (uint module = 0; module < 33; module++)
				{
				string cmd = "$" + module.ToString("X").PadLeft(2, '0') + "M" + "\r";
				rs485.Write(cmd);
				Thread.Sleep(80);
				string reply = rs485.ReadExisting();
				if (reply.Length == 8)
					{
					if (reply.Contains("7045"))
						{
						waterDev++;
						devices += "Digital " + module.ToString() + ",";
						}
					else if (reply.Contains("7018"))
						{
						weighDev++;
						devices += "Analog " + module.ToString() + ",";
						}
					}
				}
			return devices;
			}
		public void closeAllValves()
			{
			foreach (Table tbl in tables)
				{
				foreach (Pot pt in tbl.pots)
					{
					pt.stopWatering();
					}
				}
			}

		public bool valveOpen(string msg)
			{
			// return true if any valves are open
			for (int tableNo = 0; tableNo < nTables; tableNo++)
				{
				// returns if the solenoid is open. Command returns all channels in 2 hex numbers
				int addr = tableNo + 16;  //address of the digital output is tableno + 16
				string cmd = "$" + addr.ToString("X").PadLeft(2, '0') + "6\r";
				string reply = "";
				do
					{
					rs485.Write(cmd);
					Thread.Sleep(40);
					reply = rs485.ReadExisting();
					}
				while (!(reply.Length > 0 && reply[0] == '!'));
				try
					{
					int value = int.Parse(reply.Substring(3, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
					if (value > 0)
						return true;
					}
				catch (Exception ex)
					{
					string status = ex.Message + " " + reply;
					msg = status;
					}
				}

			return false;
			}

		}
	}
