using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using PectabTools.Lib;
using PectabTools.Lib.Converters;

namespace PectabToolsTests.ConverterTests {

    [TestFixture]
    public class LiveDataTests {

        #region Data

        #endregion

        #region Tests

        [Test]
        public void populate21inRecDoc3BongoRegionsJson() {

            Document doc = PectabConverter.fromPectab( TestData.BTP_LIVE_21IN_3BONGO_DOC_REC_PECTAB );

            doc.regions.addRegion( new Region() {
                name = "Receipt",
                positionRelativeToRegion = "#document"
            } );

            doc.regions.addRegion( new Region() {
                name = "MirroredSection",
                positionRelativeToRegion = "#document"
            } );

            doc.regions.addRegion( new Region() {
                name = "Bongos",
                positionRelativeToRegion = "#document"
            } );

            doc.regions.addRegion( new Region() {
                name = "Bongo1",
                positionRelativeToRegion = "Bongos"
            } );

            doc.regions.addRegion( new Region() {
                name = "Bongo2",
                positionRelativeToRegion = "Bongos"
            } );

            doc.regions.addRegion( new Region() {
                name = "Bongo3",
                positionRelativeToRegion = "Bongos"
            } );

            var json = PectabConverter.toJson( doc );

            return;
        }

        #endregion

    }
}
