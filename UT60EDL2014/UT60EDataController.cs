using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UT60EDL2014
{
    class UT60EDataController : IUT60EDataSender
    {
        public event EventHandler DataReady;

        public string id { get; private set; }
        public int unit { get; private set; }
        List<IUT60EData> data_packages;
        int parse_error_count;
        public UT60EDataController(UT60ESerialPortSettings port_settings, IUT60EDataSender package_sender)
        {
            this.id = port_settings.name;
            this.unit = port_settings.log_unit;
            package_sender.DataReady += OnDataReady;
            data_packages = new List<IUT60EData>();
        }
        void OnDataReady(object sender, EventArgs e)
        {
            UT60EPacket package = (e as UT60EPackageReceivedEventArgs).package;
            IUT60EData data = package.Parse();
            if (data == null)
            {
                parse_error_count += 1;
            }
            else if (data.Unit == unit)
                data_packages.Add(data);
            else
                data = null;
            DataReady.Invoke(this, new UT60EDataReadyEventArgs(data));
        }
    }
}
