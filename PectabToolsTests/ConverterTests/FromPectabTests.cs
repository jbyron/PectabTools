using NUnit.Framework;
using PectabTools.Lib;
using PectabTools.Lib.Atb;
using PectabTools.Lib.Btp;
using PectabTools.Lib.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace PectabToolsTests.ConverterTests {

    [TestFixture]
    public class FromPectabTests {

        [Test]
        public void fromPectabAtbSimple() {

            Document doc = PectabConverter.fromPectab( TestData.ATB_PECTAB_SIMPLE );

            Assert.IsInstanceOf<AtbDocument>( doc, "Expected doc to be type ATB" );
            Assert.AreEqual( DocumentTypes.Atb, doc.pectabType );
            Assert.AreEqual( 2, doc.fields.count );
            Assert.AreEqual( 203.2F, doc.paperWidthMm );

            return;
        }

        [Test]
        public void fromPectabBtpSimple() {

            Document doc = PectabConverter.fromPectab( TestData.BTP_PECTAB_SIMPLE );

            Assert.IsInstanceOf<BtpDocument>( doc, "Expected doc to be type BTP" );
            Assert.AreEqual( doc.pectabType, DocumentTypes.Btp );
            Assert.AreEqual( doc.fields.count, 2 );
            Assert.AreEqual( doc.paperWidthMm, 53.975F );
            Assert.AreEqual( ((BtpDocument)doc).mirrorPoint, 237 );

            return;
        }

        [Test]
        public void fromPectabAtbParseHeader() {
            Document doc = PectabConverter.fromPectab( TestData.ATB_PECTAB_SIMPLE );
            AtbDocument atb = (AtbDocument)doc;

            Assert.IsInstanceOf<AtbDocument>( doc, "Expected doc to be type ATB" );
            Assert.AreEqual( doc.pectabType, DocumentTypes.Atb );

            Assert.AreEqual( "#", atb.fieldSeparator );
            Assert.AreEqual( "?", atb.unreadableCharReplace );
            Assert.AreEqual( "M1", atb.formatCodeVersion );
            Assert.AreEqual( "A", atb.atbprSteeringCmd );
            Assert.AreEqual( "@", atb.steeringCmdLogo );
            Assert.AreEqual( ";", atb.steeringCmdColour );
            Assert.AreEqual( "GTKT", atb.transactionCodeTicket );
            Assert.AreEqual( "GCKI", atb.transactionCodeCheckin );
            Assert.AreEqual( "GBRD", atb.transactionCodeBoard );

            return;
        }

        [Test]
        public void fromPectabAtbParseMsgSimple() {
            Document doc = PectabConverter.fromPectab( TestData.ATB_PECTAB_SIMPLE );
            AtbDocument atb = (AtbDocument)doc;

            Assert.IsInstanceOf<AtbDocument>( doc, "Expected doc to be type ATB" );
            Assert.AreEqual( doc.pectabType, DocumentTypes.Atb );

            Assert.AreEqual( 1, ((AtbField)doc.fields["01"]).maxLength );

            // 0266E07D
            Assert.AreEqual( 66, ((AtbField)doc.fields["02"]).maxLength );
            Assert.AreEqual( "E", ((AtbField)doc.fields["02"]).printRow );
            Assert.AreEqual( "07", ((AtbField)doc.fields["02"]).printColumn );
            Assert.AreEqual( "D", ((AtbField)doc.fields["02"]).elementSteeringCmd );

            return;
        }

        [Test]
        public void fromPectabAtbParseMsgMultiFieldPos() {
            Document doc = PectabConverter.fromPectab( TestData.ATB_PECTAB_MULTI_POS );
            AtbDocument atb = (AtbDocument)doc;

            Assert.IsInstanceOf<AtbDocument>( doc, "Expected doc to be type ATB" );
            Assert.AreEqual( doc.pectabType, DocumentTypes.Atb );

            Assert.Fail( "Not Implemented" );

            return;
        }

        [Test]
        public void fromPectabBtpParseHeader() {

            Document doc = PectabConverter.fromPectab( TestData.BTP_PECTAB_SIMPLE );

            Assert.IsInstanceOf<BtpDocument>( doc, "Expected doc to be type BTP" );
            Assert.AreEqual( doc.pectabType, DocumentTypes.Btp );
            Assert.AreEqual( doc.fields.count, 2 );

            Assert.AreEqual( 53.975F, doc.paperWidthMm );
            Assert.AreEqual( 237, ((BtpDocument)doc).mirrorPoint );

            return;
        }

        [Test]
        public void checkPectabTypeAtb() {
            DocumentTypes docType = PectabConverter.determinePectabType( TestData.ATB_PECTAB_SIMPLE );

            Assert.AreEqual( DocumentTypes.Atb, docType, "Expected PECTAB to be of type: ATB" );
        }

        [Test]
        public void checkPectabTypeBtp() {
            DocumentTypes docType = PectabConverter.determinePectabType( TestData.BTP_PECTAB_SIMPLE );

            Assert.AreEqual( DocumentTypes.Btp, docType, "Expected PECTAB to be of type: BTP" );
        }

        [Test]
        public void checkPectabTypeCustom() {
            DocumentTypes docType = PectabConverter.determinePectabType( @"PT99?M1A#@;#GTKT#GCKI#GBRD#0101#0266E07D#" );

            Assert.AreEqual( DocumentTypes.Unknown, docType, "Expected PECTAB to be of type: Unknown" );
        }

        [Test]
        public void fromPectabBtpToJson() {

            string pectab = TestData.BTP_PECTAB_SIMPLE;
            Document doc = PectabConverter.fromPectab( pectab );
            string json = PectabConverter.toJson( doc );

            Assert.IsInstanceOf<BtpDocument>( doc, "Expected doc to be type BTP" );
            Assert.AreEqual( doc.pectabType, DocumentTypes.Btp );

            Assert.IsNotEmpty( json );

            return;
        }

    }
}
