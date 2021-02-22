using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using PectabTools.Lib;
using PectabTools.Lib.Atb;
using PectabTools.Lib.Btp;
using PectabTools.Lib.Converters;

namespace PectabToolsTests.ConverterTests {

    [TestFixture]
    public class PectabJsonTests {

        [Test]
        public void fromPectabToJsonAtbSimple() {

            Document doc = PectabConverter.fromPectab( TestData.ATB_PECTAB_JSON_SIMPLE );

            Assert.IsInstanceOf<AtbDocument>( doc, "Expected doc to be type ATB" );
            Assert.AreEqual( DocumentTypes.Atb, doc.pectabType );
            Assert.AreEqual( 2, doc.fields.count );
            Assert.AreEqual( 203.2F, doc.paperWidthMm );

            string json = PectabConverter.toJson( doc );
            Assert.IsNotEmpty( json );
            Assert.DoesNotThrow( () => JObject.Parse( json ) );

            return;
        }

        [Test]
        public void fromJsonToObjectBtpLive21() {

            Document doc = PectabConverter.fromJson( TestData.BTP_LIVE_21IN_3BONGO_DOC_REC_JSON );

            Assert.IsInstanceOf<BtpDocument>( doc, "Expected doc to be type BTP" );
            Assert.AreEqual( doc.pectabType, DocumentTypes.Btp );
            Assert.IsTrue( doc.regions.count > 3 );
            Assert.IsTrue( doc.fields.count > 5 );

            Assert.AreEqual( "03", doc.fields["01"].printPositionsRelative[0].column, "[01] .positionHorizontalRelative value is incorrect." );
            Assert.AreEqual( "138", doc.fields["01"].printPositionsRelative[0].row, "[01] .positionVerticalRelative value is incorrect." );

            return;
        }

        [Test]
        public void fromJsonToPectabBtpLive21() {

            Document doc = PectabConverter.fromJson( TestData.BTP_LIVE_21IN_3BONGO_DOC_REC_JSON );

            Assert.IsInstanceOf<BtpDocument>( doc, "Expected doc to be type BTP" );
            Assert.AreEqual( doc.pectabType, DocumentTypes.Btp );
            Assert.IsTrue( doc.regions.count > 3 );
            Assert.IsTrue( doc.fields.count > 5 );

            string pectab = PectabConverter.toPectab( doc );

            Assert.IsNotEmpty( pectab );

            return;
        }

        [Test]
        public void fromJsonToPectabBtpLive19() {

            Document doc = PectabConverter.fromJson( TestData.BTP_LIVE_19IN_DOC_3BONGO_REC_JSON );

            Assert.IsInstanceOf<BtpDocument>( doc, "Expected doc to be type BTP" );
            Assert.AreEqual( doc.pectabType, DocumentTypes.Btp );
            Assert.IsTrue( doc.regions.count > 3 );
            Assert.IsTrue( doc.fields.count > 5 );

            string pectab = PectabConverter.toPectab( doc );

            Assert.IsNotEmpty( pectab );
            Assert.AreEqual( TestData.BTP_LIVE_19IN_DOC_3BONGO_REC_PECTAB, pectab );

            return;
        }

        [Test]
        public void fromJsonToPectabBtpLive16_VJ() {
            Document doc = PectabConverter.fromJson( TestData.BTP_16IN_WORK_V1 );

            Assert.IsInstanceOf<BtpDocument>( doc, "Expected doc to be type BTP" );
            Assert.AreEqual( doc.pectabType, DocumentTypes.Btp );
            Assert.IsTrue( doc.regions.count > 3 );
            Assert.IsTrue( doc.fields.count > 5 );

            string pectab = PectabConverter.toPectab( doc );

            Assert.IsNotEmpty( pectab );
            Assert.AreEqual( TestData.BTP_16IN_WORK_V1_PT, pectab );

            return;
        }

        [Test]
        public void fromJsonToPectabDirectBtpLive21() {

            string pectab = PectabConverter.toPectab( TestData.BTP_LIVE_21IN_3BONGO_DOC_REC_JSON );

            Assert.IsNotEmpty( pectab );
            Assert.AreEqual( TestData.BTP_LIVE_21IN_3BONGO_DOC_REC_PECTAB, pectab );

            return;
        }

    }
}
