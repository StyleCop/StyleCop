/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

***************************************************************************/

using System;
using System.Collections.Generic;
using System.Globalization;

using Microsoft.VisualStudio.OLE.Interop;

namespace Microsoft.VsSDK.UnitTestLibrary
{
    public static class ConnectionPointHelper
    {
        private const string connectionPointsCollection = "ConnectionPoints";
        private static GenericMockFactory connectionPointFactory;

        private static void FindConnectionPointCallback(object sender, CallbackArgs args)
        {
            BaseMock mock = (BaseMock)sender;
            Dictionary<Guid, IConnectionPoint> connectionPoints =
                (Dictionary<Guid, IConnectionPoint>)mock[connectionPointsCollection];
            Guid eventGuid = (Guid)args.GetParameter(0);
            IConnectionPoint connectionPoint;
            if (!connectionPoints.TryGetValue(eventGuid, out connectionPoint))
            {
                // This container does not contain a connection point for this event type,
                // so set the out parameter to null and return an error.
                args.SetParameter(1, null);
                args.ReturnValue = Microsoft.VisualStudio.VSConstants.E_NOINTERFACE;
                return;
            }
            // The connection point is handled.
            args.SetParameter(1, connectionPoint);
            args.ReturnValue = Microsoft.VisualStudio.VSConstants.S_OK;
        }

        /// <summary>
        /// Given a mock object, this function will add to it a callback function to handle
        /// IConnectionPointContainer.FindConnectionPoint for all the event interfaces contained
        /// in the array passed as parameter.
        /// </summary>
        public static void AddConnectionPointsToContainer(BaseMock mockContainer, Type[] eventInterfaces)
        {
            // Check that the mock object implements IConnectionPointContainer.
            if (null == (mockContainer as IConnectionPointContainer))
            {
                throw new InvalidCastException("Parameter mockContainer does not implement IConnectionPointContainer.");
            }
            // Check if there is any interface in the array.
            if ((null == eventInterfaces) || (eventInterfaces.Length == 0))
            {
                throw new ArgumentNullException("eventIterfaces");
            }
            // Create the Dictionary that will store the connection points.
            Dictionary<Guid, IConnectionPoint> connectionPoints = new Dictionary<Guid, IConnectionPoint>();

            // Get the factory for the connection points.
            if (null == connectionPointFactory)
            {
                connectionPointFactory = new GenericMockFactory("MockLibraryConnectionPoint", new Type[] { typeof(IConnectionPoint) });
            }

            // Create a connection point for every type in the array.
            foreach (Type eventInterface in eventInterfaces)
            {
                BaseMock connectionMock = connectionPointFactory.GetInstance();
                // Set a return value for the Advise method so that the cookie will be not zero.
                connectionMock.AddMethodReturnValues(
                    string.Format(CultureInfo.InvariantCulture, "{0}.{1}", typeof(IConnectionPoint).FullName, "Advise"),
                    new object[] { null, (uint)1 });
                // Add this connection point to the dictionary.
                connectionPoints.Add(eventInterface.GUID, connectionMock as IConnectionPoint);
            }

            // Set the dictionary as member data for the container mock.
            mockContainer[connectionPointsCollection] = connectionPoints;

            // Set the callback for the FindConnectionPoint method.
            mockContainer.AddMethodCallback(
                string.Format(CultureInfo.InvariantCulture, "{0}.{1}", typeof(IConnectionPointContainer).FullName, "FindConnectionPoint"),
                new EventHandler<CallbackArgs>(FindConnectionPointCallback));
        }
    }
}
