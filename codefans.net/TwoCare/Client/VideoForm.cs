/******************************************
 * 版权所有jackch
 * QQ:106050555
 * E-mail:jackch88@hotmail.com
 * 个人Blog:http://www.jackch.cn
 * CSDN_Blog:http://blog.csdn.net/jackch88/
 * ****************************************/
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using Jackch;

namespace Jackch
{
    public partial class VideoForm : Form
    {
        private bool firstActive;                  // 第一次激活窗口
        private ArrayList capDevices;              // 视频设备列表
        private string fileName;                   // 保存视频avi文件
        private IBaseFilter capFilter;             // 视频设备的 filterinfo
        private IGraphBuilder graphBuilder;        // graphBuilder接口
        private ICaptureGraphBuilder2 capGraph;    // 捕捉Graph接口
        private IVideoWindow videoWin;             // video window interface. 
        private IMediaControl mediaCtrl;           // Media control interface
        private IMediaEventEx mediaEvt;            // Media event interface
        private bool isSave = false;
        private const int WM_GRAPHNOTIFY = 0x00008001;	// message from graph
        private const int WS_CHILD = 0x40000000;	// attributes for video window
        private const int WS_CLIPCHILDREN = 0x02000000;
        private const int WS_CLIPSIBLINGS = 0x04000000;

        public VideoForm()
        {
            InitializeComponent();
        }

        private void frmCapture_Activated()
        {
            if (firstActive) return;
            firstActive = true;

            if (!DsUtils.IsCorrectDirectXVersion())
            {
                MessageBox.Show(this, "DirectX 8.1 NOT installed!", "DirectShow.NET", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (!DsDev.GetDevicesOfCat(FilterCategory.VideoInputDevice, out capDevices))
            {
                MessageBox.Show(this, "没有发现视频设备！", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            DsDevice dev = null;
            if (capDevices.Count == 1)
                dev = capDevices[0] as DsDevice;
            else
            {
                DeviceSelector selector = new DeviceSelector(capDevices);
                selector.ShowDialog(this);
                dev = selector.SelectedDevice;
            }

            if (dev == null)
            {
                return;
            }

            if (!StartupVideo(dev.Mon))
                MessageBox.Show("初始化视频设备失败！");

        }

        /// <summary>
        /// Luoz:start all the interfaces, graphs and preview window
        /// </summary>
        bool StartupVideo(IMoniker mon)
        {
            int hr;
            try
            {
                if (!CreateCaptureDevice(mon))
                    return false;

                if (!GetInterfaces())
                    return false;

                if (!SetupGraph())
                    return false;

                if (!SetupVideoWindow())
                    return false;

#if DEBUG
                //DsROT.AddGraphToRot(graphBuilder, out rotCookie);		// graphBuilder capGraph
#endif

                hr = mediaCtrl.Run();
                if (hr < 0)
                    Marshal.ThrowExceptionForHR(hr);
                return true;
            }
            catch (Exception ee)
            {
                MessageBox.Show(this, "Could not start video stream\r\n" + ee.Message, "DirectShow.NET", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
        }

        /// <summary>
        /// Luoz: 创建用户选择的设备设备
        /// </summary>
        bool CreateCaptureDevice(IMoniker mon)
        {
            object capObj = null;
            try
            {
                Guid gbf = typeof(IBaseFilter).GUID;
                mon.BindToObject(null, null, ref gbf, out capObj);
                capFilter = (IBaseFilter)capObj; capObj = null;
                return true;
            }
            catch (Exception ee)
            {
                MessageBox.Show(this, "Could not create capture device\r\n" + ee.Message, "DirectShow.NET", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            finally
            {
                if (capObj != null)
                    Marshal.ReleaseComObject(capObj); capObj = null;
            }
        }

        /// <summary>
        /// Luoz: create the used COM components and get the interfaces
        /// </summary>
        /// <returns></returns>
        bool GetInterfaces()
        {
            Type comType = null;
            object comObj = null;
            try
            {
                comType = Type.GetTypeFromCLSID(Clsid.FilterGraph);
                if (comType == null)
                    throw new NotImplementedException(@"DirectShow FilterGraph not installed/registered!");
                comObj = Activator.CreateInstance(comType);
                graphBuilder = (IGraphBuilder)comObj; comObj = null;

                //Guid clsid = Clsid.CaptureGraphBuilder2;
                //Guid riid = typeof(ICaptureGraphBuilder2).GUID;
                //comObj = DsBugWO.CreateDsInstance(ref clsid, ref riid);
                //capGraph = (ICaptureGraphBuilder2)comObj; comObj = null;

                comType = Type.GetTypeFromCLSID(Clsid.CaptureGraphBuilder2);
                comObj = Activator.CreateInstance(comType);
                capGraph = (ICaptureGraphBuilder2)comObj; comObj = null;
                
                mediaCtrl = (IMediaControl)graphBuilder;
                videoWin = (IVideoWindow)graphBuilder;
                mediaEvt = (IMediaEventEx)graphBuilder;
                return true;
            }
            catch (Exception ee)
            {
                MessageBox.Show(this, "Could not get interfaces\r\n" + ee.Message, "DirectShow.NET", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            finally
            {
                if (comObj != null)
                    Marshal.ReleaseComObject(comObj); comObj = null;
            }
        }

        /// <summary>
        /// Luoz: build the capture graph
        /// </summary>
        /// <returns></returns>
        bool SetupGraph()
        {
            int hr;
            IBaseFilter mux = null;
            IFileSinkFilter sink = null;

            try
            {
                hr = capGraph.SetFiltergraph(graphBuilder);
                if (hr < 0)
                    Marshal.ThrowExceptionForHR(hr);

                hr = graphBuilder.AddFilter(capFilter, "Ds.NET Video Capture Device");
                if (hr < 0)
                    Marshal.ThrowExceptionForHR(hr);

                //DsUtils.ShowCapPinDialog(capGraph, capFilter, this.Handle);

                if (isSave)
                {
                    Guid sub = MediaSubType.Avi;
                    hr = capGraph.SetOutputFileName(ref sub, fileName, out mux, out sink);
                    if (hr < 0)
                        Marshal.ThrowExceptionForHR(hr);
                }

                Guid cat = PinCategory.Capture;
                Guid med = MediaType.Video;
                hr = capGraph.RenderStream(ref cat, ref med, capFilter, null, mux); // stream to file 
                if (hr < 0)
                    Marshal.ThrowExceptionForHR(hr);

                //cat = PinCategory.Preview;
                //med = MediaType.Video;
                //hr = capGraph.RenderStream(ref cat, ref med, capFilter, null, null); // preview window
                //if (hr < 0)
                //    Marshal.ThrowExceptionForHR(hr);

                return true;
            }
            catch (Exception ee)
            {
                MessageBox.Show(this, "Could not setup graph\r\n" + ee.Message, "DirectShow.NET", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            finally
            {
                if (mux != null)
                    Marshal.ReleaseComObject(mux); mux = null;
                if (sink != null)
                    Marshal.ReleaseComObject(sink); sink = null;
            }
        }

        /// <summary>
        /// Luoz： 预览
        /// </summary>
        bool SetupVideoWindow()
        {
            int hr;
            try
            {
                // Set the video window to be a child of the main window
                hr = videoWin.put_Owner(panel1.Handle);
                if (hr < 0)
                    Marshal.ThrowExceptionForHR(hr);

                // Set video window style
                hr = videoWin.put_WindowStyle(WS_CHILD | WS_CLIPCHILDREN);
                if (hr < 0)
                    Marshal.ThrowExceptionForHR(hr);

                // Use helper function to position video window in client rect of owner window
                videoWin.SetWindowPosition(0, 0, panel1.Width, panel1.Height);

                // Make the video window visible, now that it is properly positioned
                hr = videoWin.put_Visible(DsHlp.OATRUE);
                if (hr < 0)
                    Marshal.ThrowExceptionForHR(hr);

                hr = mediaEvt.SetNotifyWindow(this.Handle, WM_GRAPHNOTIFY, IntPtr.Zero);
                if (hr < 0)
                    Marshal.ThrowExceptionForHR(hr);
                return true;
            }
            catch (Exception ee)
            {
                MessageBox.Show(this, "Could not setup video window\r\n" + ee.Message, "DirectShow.NET", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmCapture_Activated();
            firstActive = false;
        }
        private void button2_Click(object sender, EventArgs e)
        {

            SaveFileDialog sd = new SaveFileDialog();
            sd.FileName = @"Billgates.avi";
            sd.Title = "Save Video Stream as...";
            sd.Filter = "Video file (*.avi)|*.avi";
            sd.FilterIndex = 1;
            if (sd.ShowDialog() != DialogResult.OK)
                return;
            fileName = sd.FileName;
            isSave = true;
        }
    }
}