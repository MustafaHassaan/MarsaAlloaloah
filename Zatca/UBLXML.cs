using Newtonsoft.Json;
using SDKNETFrameWorkLib.BLL;
using SDKNETFrameWorkLib.GeneralLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using Zatca.Models;

namespace Zatca
{
    public class DGVRows
    {
        public String Rownum { get; set; }
        public String InvoicedQuantity { get; set; }
        public String TotalAfterDiscount { get; set; }
        public String TaxAmount { get; set; }
        public String RoundingAmount { get; set; }
        public String Name { get; set; }
        public String PriceAmount { get; set; }
        public String Amount { get; set; }
    }
    public class UBLXML
    {
        public String IvoiceId { get; set; }
        public int Ivoiceno { get; set; }
        public String CRN { get; set; }
        public String StreetName { get; set; }
        public String BuildingNumber { get; set; }
        public String CitySubdivisionName { get; set; }
        public String CityName { get; set; }
        public String PostalZone { get; set; }
        public String CompanyID { get; set; }
        public String Companyname { get; set; }
        public String Invoicemethodecode { get; set; }
        public String InvoiceTypeCode { get; set; }
        public String UUID { get; set; }
        public Int32 DGVRows { get; set; }
        string cac = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2";
        string cbc = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2";
        string privateKeyContent = "MHQCAQEEIDyLDaWIn/1/g3PGLrwupV4nTiiLKM59UEqUch1vDfhpoAcGBSuBBAAKoUQDQgAEYYMMoOaFYAhMO/steotfZyavr6p11SSlwsK9azmsLY7b1b+FLhqMArhB2dqHKboxqKNfvkKDePhpqjui5hcn0Q==";
        string certificateContent = "MIID6jCCA5CgAwIBAgITbwAAfsboAdNVNKd+1wABAAB+xjAKBggqhkjOPQQDAjBjMRUwEwYKCZImiZPyLGQBGRYFbG9jYWwxEzARBgoJkiaJk/IsZAEZFgNnb3YxFzAVBgoJkiaJk/IsZAEZFgdleHRnYXp0MRwwGgYDVQQDExNUU1pFSU5WT0lDRS1TdWJDQS0xMB4XDTIyMDgxNjE0MjU0OFoXDTI0MDgxNTE0MjU0OFowTjELMAkGA1UEBhMCU0ExEzARBgNVBAoTCjMxMDIzMzM3NDYxDDAKBgNVBAsTA1RTVDEcMBoGA1UEAxMTVFNULTMxMDIzMzM3NDYwMDAwMzBWMBAGByqGSM49AgEGBSuBBAAKA0IABGGDDKDmhWAITDv7LXqLX2cmr6+qddUkpcLCvWs5rC2O29W/hS4ajAK4Qdnahym6MaijX75Cg3j4aao7ouYXJ9GjggI5MIICNTCBmgYDVR0RBIGSMIGPpIGMMIGJMTswOQYDVQQEDDIxLVRTVHwyLVRTVHwzLTBiZTk2ZTI3LWI5MTgtNDliYy05N2RiLTMzOWY1OWMyMzA0ZDEfMB0GCgmSJomT8ixkAQEMDzMxMDIzMzM3NDYwMDAwMzENMAsGA1UEDAwEMTEwMDEMMAoGA1UEGgwDVFNUMQwwCgYDVQQPDANUU1QwHQYDVR0OBBYEFDuWYlOzWpFN3no1WtyNktQdrA8JMB8GA1UdIwQYMBaAFHZgjPsGoKxnVzWdz5qspyuZNbUvME4GA1UdHwRHMEUwQ6BBoD+GPWh0dHA6Ly90c3RjcmwuemF0Y2EuZ292LnNhL0NlcnRFbnJvbGwvVFNaRUlOVk9JQ0UtU3ViQ0EtMS5jcmwwga0GCCsGAQUFBwEBBIGgMIGdMG4GCCsGAQUFBzABhmJodHRwOi8vdHN0Y3JsLnphdGNhLmdvdi5zYS9DZXJ0RW5yb2xsL1RTWkVpbnZvaWNlU0NBMS5leHRnYXp0Lmdvdi5sb2NhbF9UU1pFSU5WT0lDRS1TdWJDQS0xKDEpLmNydDArBggrBgEFBQcwAYYfaHR0cDovL3RzdGNybC56YXRjYS5nb3Yuc2Evb2NzcDAOBgNVHQ8BAf8EBAMCB4AwHQYDVR0lBBYwFAYIKwYBBQUHAwIGCCsGAQUFBwMDMCcGCSsGAQQBgjcVCgQaMBgwCgYIKwYBBQUHAwIwCgYIKwYBBQUHAwMwCgYIKoZIzj0EAwIDSAAwRQIhAMWDOI67/kAqLSDMGeUDUettoh+1dRGNHppri9d7y02vAiAtfnOLHuJBlO8QqNxXOdeQZphNYai0DDzQXmESb+6FZA==";
        string pihContent = "NWZlY2ViNjZmZmM4NmYzOGQ5NTI3ODZjNmQ2OTZjNzljMmRiYzIzOWRkNGU5MWI0NjcyOWQ3M2EyN2ZiNTdlOQ==";
        string spath = @"UBL.xml";
        public string UBLXMLGeneration(string Taxtxt,string Partprice,string TADtxt,string Tottext,List<DGVRows> DGR,string Discountmethode) {
            UBLEntity UE = new UBLEntity();
            XmlDocument XDoc = new XmlDocument();
            XDoc.Load(spath);

            XmlElement XEleid = XDoc.CreateElement("cbc", "ID", cbc);
            XEleid.InnerText = IvoiceId;
            UE.Invoiceubl = XEleid.InnerText;
            XDoc.DocumentElement.AppendChild(XEleid.Clone());

            XmlElement XEleuuid = XDoc.CreateElement("cbc", "UUID", cbc);
            Guid Gid = Guid.NewGuid();
            XEleuuid.InnerText = Gid.ToString();
            UE.UUID = Gid.ToString();
            XDoc.DocumentElement.AppendChild(XEleuuid.Clone());

            XmlElement XEleIssueDate = XDoc.CreateElement("cbc", "IssueDate", cbc);
            XEleIssueDate.InnerText = DateTime.Now.ToString("yyyy-MM-dd");
            XDoc.DocumentElement.AppendChild(XEleIssueDate.Clone());

            XmlElement XEleIssueTime = XDoc.CreateElement("cbc", "IssueTime", cbc);
            XEleIssueTime.InnerText = DateTime.Now.ToString("HH:MM:ss");
            XDoc.DocumentElement.AppendChild(XEleIssueTime.Clone());

            XmlElement XEleITC = XDoc.CreateElement("cbc", "InvoiceTypeCode", cbc);
            XEleITC.SetAttribute("name", Invoicemethodecode);
            XEleITC.InnerText = InvoiceTypeCode;
            XDoc.DocumentElement.AppendChild(XEleITC.Clone());

            XmlElement XEleNote = XDoc.CreateElement("cbc", "Note", cbc);
            XEleNote.SetAttribute("languageID", "ar");
            XEleNote.InnerText = "ABC";
            XDoc.DocumentElement.AppendChild(XEleNote.Clone());

            XmlElement XEleDCC = XDoc.CreateElement("cbc", "DocumentCurrencyCode", cbc);
            XEleDCC.InnerText = "SAR";
            XDoc.DocumentElement.AppendChild(XEleDCC.Clone());

            XmlElement XEleTCC = XDoc.CreateElement("cbc", "TaxCurrencyCode", cbc);
            XEleTCC.InnerText = "SAR";
            XDoc.DocumentElement.AppendChild(XEleTCC.Clone());

            XmlElement XEleADR = XDoc.CreateElement("cac", "AdditionalDocumentReference", cac);

            XmlElement XEleICId = XDoc.CreateElement("cbc", "ID", cbc);
            XEleICId.InnerText = "ICV";

            XmlElement XEleUid = XDoc.CreateElement("cbc", "UUID", cbc);
            XEleUid.InnerText = Ivoiceno.ToString();

            XEleADR.AppendChild(XEleICId.Clone());
            XEleADR.AppendChild(XEleUid.Clone());
            XDoc.DocumentElement.AppendChild(XEleADR.Clone());

            XmlElement XElenADR = XDoc.CreateElement("cac", "AdditionalDocumentReference", cac);

            XmlElement XElepih = XDoc.CreateElement("cbc", "ID", cbc);
            XElepih.InnerText = "PIH";
            XElenADR.AppendChild(XElepih.Clone());

            XmlElement XEleAttachment = XDoc.CreateElement("cac", "Attachment", cac);

            XmlElement XEleEDO = XDoc.CreateElement("cbc", "EmbeddedDocumentBinaryObject", cbc);
            XEleEDO.SetAttribute("mimeCode", "text/plain");
            XEleEDO.InnerText = pihContent;
            XEleAttachment.AppendChild(XEleEDO.Clone());
            XElenADR.AppendChild(XEleAttachment.Clone());
            XDoc.DocumentElement.AppendChild(XElenADR.Clone());


            XmlElement XElenASP = XDoc.CreateElement("cac", "AccountingSupplierParty", cac);

            XmlElement XEleParty = XDoc.CreateElement("cac", "Party", cac);


            XmlElement XElenPartyIdentification = XDoc.CreateElement("cac", "PartyIdentification", cac);
            XmlElement PIID = XDoc.CreateElement("cbc", "ID", cbc);
            PIID.SetAttribute("schemeID", "CRN");
            PIID.InnerText = CRN;
            XElenPartyIdentification.AppendChild(PIID.Clone());
            XEleParty.AppendChild(XElenPartyIdentification.Clone());

            XmlElement XElenPostalAddress = XDoc.CreateElement("cac", "PostalAddress", cac);
            XmlElement SuppSTN = XDoc.CreateElement("cbc", "StreetName", cbc);
            SuppSTN.InnerText = StreetName;
            XElenPostalAddress.AppendChild(SuppSTN.Clone());

            XmlElement SuppBNumber = XDoc.CreateElement("cbc", "BuildingNumber", cbc);
            SuppBNumber.InnerText = BuildingNumber;
            XElenPostalAddress.AppendChild(SuppBNumber.Clone());

            XmlElement SuppCSName = XDoc.CreateElement("cbc", "CitySubdivisionName", cbc);
            SuppCSName.InnerText = CitySubdivisionName;
            XElenPostalAddress.AppendChild(SuppCSName.Clone());

            XmlElement SuppCityName = XDoc.CreateElement("cbc", "CityName", cbc);
            SuppCityName.InnerText = CityName;
            XElenPostalAddress.AppendChild(SuppCityName.Clone());

            XmlElement SuppPZ = XDoc.CreateElement("cbc", "PostalZone", cbc);
            SuppPZ.InnerText = PostalZone;
            XElenPostalAddress.AppendChild(SuppPZ.Clone());

            XmlElement SuppCountry = XDoc.CreateElement("cac", "Country", cac);

            XmlElement SuppIC = XDoc.CreateElement("cbc", "IdentificationCode", cbc);
            SuppIC.InnerText = "SA";
            SuppCountry.AppendChild(SuppIC.Clone());
            XElenPostalAddress.AppendChild(SuppCountry.Clone());
            XEleParty.AppendChild(XElenPostalAddress.Clone());

            XmlElement XElenPartyTaxScheme = XDoc.CreateElement("cac", "PartyTaxScheme", cac);

            XmlElement Suppcoid = XDoc.CreateElement("cbc", "CompanyID", cbc);
            Suppcoid.InnerText = CompanyID;
            XElenPartyTaxScheme.AppendChild(Suppcoid.Clone());

            XmlElement TaxScheme = XDoc.CreateElement("cac", "TaxScheme", cac);

            XmlElement IDTaxScheme = XDoc.CreateElement("cbc", "ID", cbc);
            IDTaxScheme.InnerText = "VAT";
            TaxScheme.AppendChild(IDTaxScheme);

            XElenPartyTaxScheme.AppendChild(TaxScheme);
            XEleParty.AppendChild(XElenPartyTaxScheme.Clone());


            XmlElement XElenPartyLegalEntity = XDoc.CreateElement("cac", "PartyLegalEntity", cac);
            XmlElement RegistrationName = XDoc.CreateElement("cbc", "RegistrationName", cbc);
            RegistrationName.InnerText = Companyname;
            //"مؤسسة وليد محمد عبدالله للتجارة | Waleed M. A. Est For Trading";
            XElenPartyLegalEntity.AppendChild(RegistrationName.Clone());
            XEleParty.AppendChild(XElenPartyLegalEntity.Clone());
            XElenASP.AppendChild(XEleParty.Clone());


            //=============================  AccountingCustomerParty  =================================//

            XmlElement AccountingCustomerParty = XDoc.CreateElement("cac", "AccountingCustomerParty", cac);

            XmlElement Accountcustomerparty = XDoc.CreateElement("cac", "Party", cac);
            AccountingCustomerParty.AppendChild(Accountcustomerparty);

            XmlElement PostalAddress2 = XDoc.CreateElement("cac", "PostalAddress", cac);

            XmlElement CustSTN = XDoc.CreateElement("cbc", "StreetName", cbc);
            CustSTN.InnerText = "";

            XmlElement CustBNumber = XDoc.CreateElement("cbc", "BuildingNumber", cbc);
            CustBNumber.InnerText = "";

            XmlElement CustCSName = XDoc.CreateElement("cbc", "CitySubdivisionName", cbc);
            CustCSName.InnerText = "";

            XmlElement CustCityName = XDoc.CreateElement("cbc", "CityName", cbc);
            CustCityName.InnerText = "";

            XmlElement CustPZ = XDoc.CreateElement("cbc", "PostalZone", cbc);
            CustPZ.InnerText = "";

            XmlElement CustCountry = XDoc.CreateElement("cac", "Country", cac);

            XmlElement CustIC = XDoc.CreateElement("cbc", "IdentificationCode", cbc);
            CustIC.InnerText = "SA";

            PostalAddress2.AppendChild(CustSTN.Clone());
            PostalAddress2.AppendChild(CustBNumber.Clone());
            PostalAddress2.AppendChild(CustCSName.Clone());
            PostalAddress2.AppendChild(CustCityName.Clone());
            PostalAddress2.AppendChild(CustPZ.Clone());
            PostalAddress2.AppendChild(CustCountry);
            CustCountry.AppendChild(CustIC.Clone());

            Accountcustomerparty.AppendChild(PostalAddress2.Clone());

            XmlElement PartyTaxScheme2 = XDoc.CreateElement("cac", "PartyTaxScheme", cac);

            XmlElement Cstcoid = XDoc.CreateElement("cbc", "CompanyID", cbc);
            Cstcoid.InnerText = "";

            XmlElement TaxScheme2 = XDoc.CreateElement("cac", "TaxScheme", cac);

            XmlElement ID6 = XDoc.CreateElement("cbc", "ID", cbc);
            ID6.InnerText = "VAT";

            PartyTaxScheme2.AppendChild(Cstcoid);
            TaxScheme2.AppendChild(ID6.Clone());
            PartyTaxScheme2.AppendChild(TaxScheme2.Clone());
            Accountcustomerparty.AppendChild(PartyTaxScheme2.Clone());

            XmlElement PartyLegalEntity2 = XDoc.CreateElement("cac", "PartyLegalEntity", cac);

            XmlElement RegistrationName2 = XDoc.CreateElement("cbc", "RegistrationName", cbc);
            RegistrationName2.InnerText = "";

            PartyLegalEntity2.AppendChild(RegistrationName2.Clone());
            Accountcustomerparty.AppendChild(PartyLegalEntity2.Clone());
            //============================= End AccountingCustomerParty  =================================//
            XmlElement PaymentMeans = XDoc.CreateElement("cac", "PaymentMeans", cac);
            XmlElement PaymentMeansCode = XDoc.CreateElement("cbc", "PaymentMeansCode", cbc);
            PaymentMeansCode.InnerText = UUID;
            PaymentMeans.AppendChild(PaymentMeansCode.Clone());
            //============================= AllowanceCharge  =================================//

            XmlElement AllowanceCharge = XDoc.CreateElement("cac", "AllowanceCharge", cac);
            XmlElement ChargeIndicator = XDoc.CreateElement("cbc", "ChargeIndicator", cbc);
            XmlElement AllowanceChargeReason = XDoc.CreateElement("cbc", "AllowanceChargeReason", cbc);
            XmlElement Amount = XDoc.CreateElement("cbc", "Amount", cbc);
            Amount.SetAttribute("currencyID", "SAR");
            if (Discountmethode == "خصم على المنتج")
            {
                ChargeIndicator.InnerText = "false";
            }
            else
            {
                ChargeIndicator.InnerText = "true";
            }
            AllowanceChargeReason.InnerText = "discount";
            Amount.InnerText = "0.00";
            AllowanceCharge.AppendChild(ChargeIndicator);
            AllowanceCharge.AppendChild(AllowanceChargeReason);
            AllowanceCharge.AppendChild(Amount);

            for (int i = 0; i < DGVRows; i++)
            {
                XmlElement TaxCategory = XDoc.CreateElement("cac", "TaxCategory", cac);

                XmlElement ID8 = XDoc.CreateElement("cbc", "ID", cbc);
                ID8.InnerText = "S";
                ID8.SetAttribute("schemeAgencyID", "6");
                ID8.SetAttribute("schemeID", "UN/ECE 5305");

                XmlElement Percent = XDoc.CreateElement("cbc", "Percent", cbc);
                Percent.InnerText = "15";

                XmlElement TaxScheme1 = XDoc.CreateElement("cac", "TaxScheme", cac);

                XmlElement ID9 = XDoc.CreateElement("cbc", "ID", cbc);
                ID9.InnerText = "VAT";
                ID9.SetAttribute("schemeAgencyID", "6");
                ID9.SetAttribute("schemeID", "UN/ECE 5153");

                TaxCategory.AppendChild(ID8);
                TaxCategory.AppendChild(Percent);
                TaxScheme1.AppendChild(ID9);
                TaxCategory.AppendChild(TaxScheme1);
                AllowanceCharge.AppendChild(TaxCategory);
            }
            //============================= End AllowanceCharge  =================================//


            XmlElement TaxTotal = XDoc.CreateElement("cac", "TaxTotal", cac);
            XmlElement TaxAmount = XDoc.CreateElement("cbc", "TaxAmount", cbc);
            TaxAmount.InnerText = Taxtxt;
            TaxAmount.SetAttribute("currencyID", "SAR");

            XmlElement TaxTotalall = XDoc.CreateElement("cac", "TaxTotal", cac);
            XmlElement TaxAmountall = XDoc.CreateElement("cbc", "TaxAmount", cbc);
            TaxAmountall.InnerText = Taxtxt;
            TaxAmountall.SetAttribute("currencyID", "SAR");

            XmlElement TaxSubtotal = XDoc.CreateElement("cac", "TaxSubtotal", cac);

            XmlElement TaxableAmount = XDoc.CreateElement("cbc", "TaxableAmount", cbc);
            TaxableAmount.InnerText = Convert.ToString(Convert.ToDecimal(Partprice));
            TaxableAmount.SetAttribute("currencyID", "SAR");


            XmlElement TaxAmount1 = XDoc.CreateElement("cbc", "TaxAmount", cbc);
            TaxAmount1.InnerText = Taxtxt;
            TaxAmount1.SetAttribute("currencyID", "SAR");

            XmlElement TaxCategory1 = XDoc.CreateElement("cac", "TaxCategory", cac);

            XmlElement ID0 = XDoc.CreateElement("cbc", "ID", cbc);
            ID0.InnerText = "S";
            ID0.SetAttribute("schemeID", "UN/ECE 5305");
            ID0.SetAttribute("schemeAgencyID", "6");

            XmlElement Percenttc = XDoc.CreateElement("cbc", "Percent", cbc);
            Percenttc.InnerText = "15.00";

            XmlElement TaxSchemes = XDoc.CreateElement("cac", "TaxScheme", cac);

            XmlElement IDs = XDoc.CreateElement("cbc", "ID", cbc);
            IDs.InnerText = "VAT";
            IDs.SetAttribute("schemeID", "UN/ECE 5153");
            IDs.SetAttribute("schemeAgencyID", "6");


            //============================= LegalMonetaryTotal  =================================//

            XmlElement LegalMonetaryTotal = XDoc.CreateElement("cac", "LegalMonetaryTotal", cac);

            XmlElement LineExtensionAmount = XDoc.CreateElement("cbc", "LineExtensionAmount", cbc);
            LineExtensionAmount.InnerText = Convert.ToString(Convert.ToDecimal(TADtxt));
            LineExtensionAmount.SetAttribute("currencyID", "SAR");

            XmlElement TaxExclusiveAmount = XDoc.CreateElement("cbc", "TaxExclusiveAmount", cbc);
            TaxExclusiveAmount.InnerText = Convert.ToString(Convert.ToDecimal(TADtxt));
            TaxExclusiveAmount.SetAttribute("currencyID", "SAR");

            XmlElement TaxInclusiveAmount = XDoc.CreateElement("cbc", "TaxInclusiveAmount", cbc);
            TaxInclusiveAmount.InnerText = Convert.ToString(Convert.ToDecimal(Tottext));
            TaxInclusiveAmount.SetAttribute("currencyID", "SAR");

            XmlElement AllowanceTotalAmount = XDoc.CreateElement("cbc", "AllowanceTotalAmount", cbc);
            AllowanceTotalAmount.InnerText = "0.00";
            AllowanceTotalAmount.SetAttribute("currencyID", "SAR");

            XmlElement PrepaidAmount = XDoc.CreateElement("cbc", "PrepaidAmount", cbc);
            PrepaidAmount.InnerText = "0.00";
            PrepaidAmount.SetAttribute("currencyID", "SAR");

            XmlElement PayableAmount = XDoc.CreateElement("cbc", "PayableAmount", cbc);
            PayableAmount.InnerText = Convert.ToString(Convert.ToDecimal(Tottext));
            PayableAmount.SetAttribute("currencyID", "SAR");

            //============================= End LegalMonetaryTotal  =================================//

            TaxTotal.AppendChild(TaxAmount.Clone());


            TaxTotalall.AppendChild(TaxAmountall.Clone());

            TaxSubtotal.AppendChild(TaxableAmount.Clone());
            TaxSubtotal.AppendChild(TaxAmount1.Clone());
            TaxCategory1.AppendChild(ID0.Clone());
            TaxCategory1.AppendChild(Percenttc.Clone());
            TaxSchemes.AppendChild(IDs.Clone());
            TaxCategory1.AppendChild(TaxSchemes.Clone());
            TaxSubtotal.AppendChild(TaxCategory1.Clone());

            TaxTotalall.AppendChild(TaxSubtotal.Clone());


            LegalMonetaryTotal.AppendChild(LineExtensionAmount.Clone());
            LegalMonetaryTotal.AppendChild(TaxExclusiveAmount.Clone());
            LegalMonetaryTotal.AppendChild(TaxInclusiveAmount.Clone());
            LegalMonetaryTotal.AppendChild(AllowanceTotalAmount.Clone());
            LegalMonetaryTotal.AppendChild(PrepaidAmount.Clone());
            LegalMonetaryTotal.AppendChild(PayableAmount.Clone());

            XDoc.DocumentElement.AppendChild(XElenASP.Clone());
            XDoc.DocumentElement.AppendChild(AccountingCustomerParty.Clone());
            XDoc.DocumentElement.AppendChild(PaymentMeans.Clone());
            XDoc.DocumentElement.AppendChild(AllowanceCharge.Clone());
            XDoc.DocumentElement.AppendChild(TaxTotal.Clone());
            XDoc.DocumentElement.AppendChild(TaxTotalall.Clone());
            XDoc.DocumentElement.AppendChild(LegalMonetaryTotal.Clone());

            //============================= InvoiceLine  =================================//
            XmlElement InvoiceLine = XDoc.DocumentElement;
            for (int i = 0; i < DGR.Count; i++)
            {
                InvoiceLine = XDoc.CreateElement("cac", "InvoiceLine", cac);

                XmlElement ID11 = XDoc.CreateElement("cbc", "ID", cbc);
                ID11.InnerText = DGR[i].Rownum;

                XmlElement InvoicedQuantity = XDoc.CreateElement("cbc", "InvoicedQuantity", cbc);
                InvoicedQuantity.InnerText = DGR[i].InvoicedQuantity + ".000000";
                InvoicedQuantity.SetAttribute("unitCode", "PCE");

                XmlElement LineExtensionAmount1 = XDoc.CreateElement("cbc", "LineExtensionAmount", cbc);
                //var Partprice = Convert.ToDouble(DGV.Rows[i].Cells[7].Value.ToString());
                LineExtensionAmount1.InnerText = DGR[i].TotalAfterDiscount;

                XmlElement TaxTotalline = XDoc.CreateElement("cac", "TaxTotal", cac);

                XmlElement TaxAmountline = XDoc.CreateElement("cbc", "TaxAmount", cbc);
                TaxAmountline.InnerText = DGR[i].TaxAmount;
                //TaxAmountline.InnerText = DGR.TaxAmount;
                TaxAmountline.SetAttribute("currencyID", "SAR");

                XmlElement RoundingAmount = XDoc.CreateElement("cbc", "RoundingAmount", cbc);
                RoundingAmount.InnerText = DGR[i].RoundingAmount;
                //RoundingAmount.InnerText = DGR.RoundingAmount;
                RoundingAmount.SetAttribute("currencyID", "SAR");

                XmlElement Item = XDoc.CreateElement("cac", "Item", cac);

                XmlElement Name = XDoc.CreateElement("cbc", "Name", cbc);
                Name.InnerText = DGR[i].Name;

                XmlElement ClassifiedTaxCategory = XDoc.CreateElement("cac", "ClassifiedTaxCategory", cac);

                XmlElement ID12 = XDoc.CreateElement("cbc", "ID", cbc);
                ID12.InnerText = "S";

                XmlElement Percent2 = XDoc.CreateElement("cbc", "Percent", cbc);
                Percent2.InnerText = "15.00";

                XmlElement TaxSchemep = XDoc.CreateElement("cac", "TaxScheme", cac);

                XmlElement ID1t = XDoc.CreateElement("cbc", "ID", cbc);
                ID1t.InnerText = "VAT";

                XmlElement Price = XDoc.CreateElement("cac", "Price", cac);

                XmlElement PriceAmount = XDoc.CreateElement("cbc", "PriceAmount", cbc);
                //PriceAmount.InnerText = Convert.ToString(DGV.Rows[i].Cells[3].Value.ToString());
                PriceAmount.InnerText = DGR[i].PriceAmount;
                PriceAmount.SetAttribute("currencyID", "SAR");

                XmlElement AllowanceChargeline = XDoc.CreateElement("cac", "AllowanceCharge", cac);

                XmlElement ChargeIndicatorline = XDoc.CreateElement("cbc", "ChargeIndicator", cbc);
                if (Discountmethode == "خصم على مستوى الفاتورة")
                {
                    ChargeIndicatorline.InnerText = "true";
                }
                else
                {
                    ChargeIndicatorline.InnerText = "false";
                }

                XmlElement AllowanceChargeReasonline = XDoc.CreateElement("cbc", "AllowanceChargeReason", cbc);
                AllowanceChargeReasonline.InnerText = "discount";

                XmlElement Amountline = XDoc.CreateElement("cbc", "Amount", cbc);
                //Amountline.InnerText = DGR.Rows[i].Cells[6].Value.ToString());
                Amountline.InnerText = DGR[i].Amount;
                Amountline.SetAttribute("currencyID", "SAR");

                InvoiceLine.AppendChild(ID11.Clone());
                InvoiceLine.AppendChild(InvoicedQuantity.Clone());
                InvoiceLine.AppendChild(LineExtensionAmount1.Clone());
                TaxTotalline.AppendChild(TaxAmountline.Clone());
                TaxTotalline.AppendChild(RoundingAmount.Clone());
                InvoiceLine.AppendChild(TaxTotalline.Clone());
                Item.AppendChild(Name.Clone());
                ClassifiedTaxCategory.AppendChild(ID12.Clone());
                ClassifiedTaxCategory.AppendChild(Percent2.Clone());
                TaxSchemep.AppendChild(ID1t.Clone());
                ClassifiedTaxCategory.AppendChild(TaxSchemep.Clone());
                Item.AppendChild(ClassifiedTaxCategory.Clone());
                InvoiceLine.AppendChild(Item.Clone());
                Price.AppendChild(PriceAmount.Clone());
                AllowanceChargeline.AppendChild(ChargeIndicatorline.Clone());
                AllowanceChargeline.AppendChild(AllowanceChargeReasonline.Clone());
                AllowanceChargeline.AppendChild(Amountline.Clone());
                Price.AppendChild(AllowanceChargeline.Clone());
                InvoiceLine.AppendChild(Price.Clone());
                XDoc.DocumentElement.AppendChild(InvoiceLine.Clone());
            }
            //============================= End InvoiceLine  =================================//

            //var MP = @"C:\Integrated Entity\Marsa With Daily Landing Payments\MarsaAlloaloah\MarsaAlloaloah\bin\Debug\";
            var NP = @"UBLSinged.xml";
            XDoc.Save(NP);

            Result objResult = new Result();
            QRValidator QRV = new QRValidator();
            EInvoiceSigningLogic EiSL = new EInvoiceSigningLogic();
            objResult = EiSL.SignDocument(NP, certificateContent, privateKeyContent);

            NP = @"Invoice/UBLSinged-" + XEleid.InnerText + "-" + DateTime.Now.ToString("yyyy-MM-dd") + ".xml";
            var objWriter = new StreamWriter(NP);

            objWriter.Write(objResult.ResultedValue);
            File.Delete(@"UBLSinged.xml");
            objWriter.Close();
            objResult = QRV.GenerateEInvoiceQRCode(NP);
            var QR = objResult.ResultedValue;
            UE.QRCode = QR;
            UE.Invoiceno = Ivoiceno;
            var Json = JsonConvert.SerializeObject(UE);
            return Json;
        }
    }
}
