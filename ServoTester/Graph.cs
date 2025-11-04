using ScottPlot;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServoTester
{
  public class _Graph
  {
    public bool CheckGraphCommandSpeed = false;
    public bool CheckGraphCommandCurrent = false;
    public bool CheckGraphFeedSpeed = false;
    public bool CheckGraphFeedCurrent = false;
    Form1 form = null;
    _comm Comm = null;
    ScottPlot.WinForms.FormsPlot formsPlot = null;
    double LineStart = 0;
    int ii;

    public _Graph(Form1 _form)
    {
      form = _form;
      Comm = form.Comm;
      formsPlot = form.formsPlot;
      ii = 0;
    }

    public void Refresh_graph()
    {
      double[] data1 = new double[50];
      double[] data2 = new double[50];
      double[] data3 = new double[50];
      double[] data4 = new double[50];
      for (int i = ii; i < ii+50; i++)
      {
        data1[i-ii] = Math.Sin(i * 0.01) * 1;
        data2[i-ii] = Math.Sin(i * 0.01) * 2;
        data3[i-ii] = Math.Sin(i * 0.01) * 3;
        data4[i-ii] = Math.Sin(i * 0.01) * 4;
      }
      ii += 50;

      Comm.Graph_ch1.AddRange(data1);
      Comm.Graph_ch2.AddRange(data2);
      Comm.Graph_ch3.AddRange(data3);
      Comm.Graph_ch4.AddRange(data4);
      Comm.GraphUpdate = true;

      List<double> Graph_ch1 = new List<double>(); //Comm.Graph_ch1.ToList();
      List<double> Graph_ch2 = new List<double>(); //Comm.Graph_ch2.ToList();
      List<double> Graph_ch3 = new List<double>(); //Comm.Graph_ch3.ToList();
      List<double> Graph_ch4 = new List<double>(); //Comm.Graph_ch4.ToList();
      List<double> Graph_time = new List<double>();

      formsPlot.Plot.Clear();
      if (Comm.Graph_ch1.Count < 1000)
      {
        LineStart = 0;
        for (int i = 0; i < Comm.Graph_ch1.Count; i++)
        {
          Graph_time.Add(5e-3d * (double)i);
          Graph_ch1.Add(Comm.Graph_ch1[i]);
          Graph_ch2.Add(Comm.Graph_ch2[i]);
          Graph_ch3.Add(Comm.Graph_ch3[i]);
          Graph_ch4.Add(Comm.Graph_ch4[i]);
        }
      }
      else
      {
        LineStart = 5e-3d * (Comm.Graph_ch1.Count - 1000);
        for (int i = Comm.Graph_ch1.Count - 1000; i < Comm.Graph_ch1.Count; i++)
        {
          Graph_time.Add(5e-3d * (double)i);
          Graph_ch1.Add(Comm.Graph_ch1[i]);
          Graph_ch2.Add(Comm.Graph_ch2[i]);
          Graph_ch3.Add(Comm.Graph_ch3[i]);
          Graph_ch4.Add(Comm.Graph_ch4[i]);
        }
      }

      if (CheckGraphCommandSpeed)
      {
        var sig1 = formsPlot.Plot.Add.ScatterLine(Graph_time, Graph_ch1);
        sig1.LegendText = "CommandSpeed";
      }

      if (CheckGraphCommandCurrent)
      {
        var sig1 = formsPlot.Plot.Add.ScatterLine(Graph_time, Graph_ch2);
        sig1.LegendText = "CommandCurrent";
      }

      if (CheckGraphFeedSpeed)
      {
        var sig1 = formsPlot.Plot.Add.ScatterLine(Graph_time, Graph_ch3);
        sig1.LegendText = "SpeedSpeed";
      }

      if (CheckGraphFeedCurrent)
      {
        var sig1 = formsPlot.Plot.Add.ScatterLine(Graph_time, Graph_ch4);
        sig1.LegendText = "SpeedCurrent";
      }

      formsPlot.Plot.ShowLegend(Alignment.UpperRight);

      formsPlot.Plot.Axes.AutoScale();

      var vl = formsPlot.Plot.Add.VerticalLine(LineStart);
      vl.IsDraggable = true;
      vl.Text = $"{vl.X:0.00}";//"VLine";

      var hl = formsPlot.Plot.Add.HorizontalLine(0);
      hl.IsDraggable = true;
      hl.Text = $"{hl.Y:0.00}";//"HLine";

      formsPlot.Refresh();
    }
  }
}
