using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryClock {
	class BinaryClock {

		private String[] _values = new String[]
			{"----","*---","-*--","**--","--*-","*-*-","-**-","***-","---*","*--*"};

		public void DisplayHours()
		{
			int column = 2;
			int myTime = DateTime.Now.Hour;
			if (myTime < 10) {
				DisplayBinaryNumber(GetIntegerAtLocation(0, 0), column);
				DisplayBinaryNumber(GetIntegerAtLocation(myTime, 1), column + 1);
			}
			else {
				DisplayBinaryNumber(GetIntegerAtLocation(myTime, 0), column);
				DisplayBinaryNumber(GetIntegerAtLocation(myTime, 1), column + 1);
			}
		}

		public void DisplayMinutes()
		{
			int column = 5;
			int myTime = DateTime.Now.Minute;
			if (myTime < 10) {
				DisplayBinaryNumber(GetIntegerAtLocation(0, 0), column);
				DisplayBinaryNumber(GetIntegerAtLocation(myTime, 1), column + 1);
			}
			else {
				DisplayBinaryNumber(GetIntegerAtLocation(myTime, 0), column);
				DisplayBinaryNumber(GetIntegerAtLocation(myTime, 1), column + 1);
			}

		}

		public void DisplaySeconds()
		{
			int column = 8;
			int myTime = DateTime.Now.Second;
			if (myTime<10) {
				DisplayBinaryNumber(GetIntegerAtLocation(0, 0), column);
				DisplayBinaryNumber(GetIntegerAtLocation(myTime, 1), column + 1);
			}
			else {
				DisplayBinaryNumber(GetIntegerAtLocation(myTime, 0), column);
				DisplayBinaryNumber(GetIntegerAtLocation(myTime, 1), column + 1);
			}
		}

		public void ClearConsole()
		{
			Console.Clear();
		}

		public void DisplayBinaryNumber(int NumberToDisplay, int Column)
		{
			for (int cnt = 0; cnt <= 3; cnt++) {
				if (_values[NumberToDisplay].Substring(cnt,1) == "*") {
					Console.SetCursorPosition(Column, 5 - cnt);
					Console.Write("@");
				}
				else {
					Console.SetCursorPosition(Column, 5 - cnt);
					Console.Write("-");
				}
			}
		}

		public int GetIntegerAtLocation(int iValue, int Location)
		{
			if (iValue < 10) {
				Location = 0;
			}
			String sValue = iValue.ToString();
			String locationValue = sValue.Substring(Location, 1);
			int result;
			int.TryParse(locationValue, out result);
			return result;
		}
	}
}
