using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using PectabTools.Lib;
using PectabTools.Lib.Converters;

namespace PectabToolsTests.ConverterTests {

    [TestFixture]
    public class PectabTypeTests {


        [Test]
        public void determinePectabTypeAtbSimple() {

            DocumentTypes docType = PectabConverter.determinePectabType ( TestData.ATB_PECTAB_SIMPLE );

            Assert.AreEqual( DocumentTypes.Atb, docType );
        }

        [Test]
        public void determinePectabTypeInvalid() {

            DocumentTypes docType = PectabConverter.determinePectabType( "ABCDEF" );

            Assert.AreEqual( DocumentTypes.Unknown, docType );
        }

        [Test]
        public void determinePectabTypeBtpSimple() {

            DocumentTypes docType = PectabConverter.determinePectabType( TestData.BTP_PECTAB_SIMPLE );

            Assert.AreEqual( DocumentTypes.Btp, docType );
        }

    }
}
