using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVGK
{
    class ModelsAngel
    {
   //     <?xml version = "1.0" encoding="UTF-8"?>
   //<xs:schema xmlns:xs="http://www.w3.org/2001/XMLSchema" elementFormDefault="qualified" attributeFormDefault="unqualified">
   //      <!-- XML Schema Generated from XML Document on Tue Mar 06 2018 11:41:41 GMT+0300 (RTZ 2 (зима)) -->
   //      <!-- with XmlGrid.net Free Online Service http://xmlgrid.net -->
   //      <xs:element name = "CaseData" >
   //            < xs:complexType>
   //                  <xs:sequence>
   //                        <xs:element name = "CaseViolation" >
   //                              < xs:complexType>
   //                                    <xs:sequence>
   //                                          <xs:element name = "EquipmentName" type= "xs:string" ></ xs:element>
   //                                          <xs:element name = "EquipmentID" type= "xs:string" ></ xs:element>
   //                                          <xs:element name = "EquipmentType" type= "xs:string" ></ xs:element>
   //                                          <xs:element name = "EquipmentSeriaNumber" type= "xs:int" ></ xs:element>
   //                                          <xs:element name = "EquipmentOwner" type= "xs:string" ></ xs:element>
   //                                          <xs:element name = "CertificateStatementSuchMeasurementNumber" type= "xs:int" ></ xs:element>
   //                                          <xs:element name = "CertificateStatementSuchMeasurementDate" type= "xs:dateTime" ></ xs:element>
   //                                          <xs:element name = "CertificateStatementSuchMeasurementRegistrationNumber" type= "xs:int" ></ xs:element>
   //                                          <xs:element name = "CheckingDocNumber" type= "xs:string" ></ xs:element>
   //                                          <xs:element name = "CheckingCertificateDate" type= "xs:dateTime" ></ xs:element>
   //                                          <xs:element name = "CheckingValid" type= "xs:dateTime" ></ xs:element>
   //                                          <xs:element name = "Place" type= "xs:string" ></ xs:element>
   //                                          <xs:element name = "HighwayName" type= "xs:string" ></ xs:element>
   //                                          <xs:element name = "FactID" type= "xs:string" ></ xs:element>
   //                                          <xs:element name = "ViolationDateTime" type= "xs:dateTime" ></ xs:element>
   //                                          <xs:element name = "StateNumber" type= "xs:string" ></ xs:element>
   //                                          <xs:element name = "MovementDirection" type= "xs:string" ></ xs:element>
   //                                          <xs:element name = "QuantityAxes" type= "xs:int" ></ xs:element>
   //                                          <xs:element name = "ActID" type= "xs:int" ></ xs:element>
   //                                          <xs:element name = "SpecialPermissionSign" type= "xs:string" ></ xs:element>
   //                                          <xs:element name = "SpecialPermissionNumber" ></ xs:element>
   //                                          <xs:element name = "SpecialPermissionRegistrationDate" type= "xs:dateTime" ></ xs:element>
   //                                          <xs:element name = "ExcessAxesSign" type= "xs:string" ></ xs:element>
   //                                          <xs:element name = "ExcessFullWeightSign" type= "xs:string" ></ xs:element>
   //                                          <xs:element name = "ExcessLengthSign" type= "xs:string" ></ xs:element>
   //                                          <xs:element name = "ExcessHeightSign" type= "xs:string" ></ xs:element>
   //                                          <xs:element name = "ExcessWidthSign" type= "xs:string" ></ xs:element>
   //                                          <xs:element name = "ResolvedLoadAxisMax" type= "xs:int" ></ xs:element>
   //                                          <xs:element name = "TrackCategory" type= "xs:int" ></ xs:element>
   //                                          <xs:element name = "TrackType" type= "xs:int" ></ xs:element>
   //                                          <xs:element name = "SpecialPermissionCompany" ></ xs:element>
   //                                          <xs:element name = "SpecialPermissionStartDate" type= "xs:dateTime" ></ xs:element>
   //                                          <xs:element name = "SpecialPermissionEndDate" type= "xs:dateTime" ></ xs:element>
   //                                          <xs:element name = "RouteViolationSign" type= "xs:string" ></ xs:element>
   //                                          <xs:element name = "TripCountFact" type= "xs:int" ></ xs:element>
   //                                          <xs:element name = "RoadType" type= "xs:string" ></ xs:element>
   //                                          <xs:element name = "ExcessFactMedia" maxOccurs= "unbounded" type= "xs:string" ></ xs:element>
   //                                    </xs:sequence>
   //                              </xs:complexType>
   //                        </xs:element>
   //                        <xs:element name = "SpeedViolation" >
   //                              < xs:complexType>
   //                                    <xs:sequence>
   //                                          <xs:element name = "Speed" type= "xs:int" ></ xs:element>
   //                                          <xs:element name = "SpeedWIM" type= "xs:int" ></ xs:element>
   //                                          <xs:element name = "DifferenceSpeedPermissionFact" type= "xs:int" ></ xs:element>
   //                                          <xs:element name = "ExcessSpeed" type= "xs:string" ></ xs:element>
   //                                    </xs:sequence>
   //                              </xs:complexType>
   //                        </xs:element>
   //                        <xs:element name = "DimensionViolation" >
   //                              < xs:complexType>
   //                                    <xs:sequence>
   //                                          <xs:element name = "LengthNorm" type= "xs:int" ></ xs:element>
   //                                          <xs:element name = "WidthNorm" type= "xs:double" ></ xs:element>
   //                                          <xs:element name = "HeightNorm" type= "xs:int" ></ xs:element>
   //                                          <xs:element name = "ExtraLength" type= "xs:int" ></ xs:element>
   //                                          <xs:element name = "ExtraWidth" type= "xs:int" ></ xs:element>
   //                                          <xs:element name = "ExtraHeight" type= "xs:int" ></ xs:element>
   //                                          <xs:element name = "LengthPermission" type= "xs:int" ></ xs:element>
   //                                          <xs:element name = "WidthPermission" type= "xs:int" ></ xs:element>
   //                                          <xs:element name = "HeightPermission" type= "xs:int" ></ xs:element>
   //                                          <xs:element name = "LengthFact" type= "xs:double" ></ xs:element>
   //                                          <xs:element name = "WidthFact" type= "xs:double" ></ xs:element>
   //                                          <xs:element name = "HeightFact" type= "xs:double" ></ xs:element>
   //                                          <xs:element name = "DifferenceLengthNormaFact" type= "xs:int" ></ xs:element>
   //                                          <xs:element name = "DifferenceWidthNormaFact" type= "xs:int" ></ xs:element>
   //                                          <xs:element name = "DifferenceHeightNormaFact" type= "xs:int" ></ xs:element>
   //                                          <xs:element name = "DifferenceLengthPermissionFact" type= "xs:int" ></ xs:element>
   //                                          <xs:element name = "DifferenceWidthPermissionFact" type= "xs:int" ></ xs:element>
   //                                          <xs:element name = "DifferenceHeightPermissionFact" type= "xs:int" ></ xs:element>
   //                                    </xs:sequence>
   //                              </xs:complexType>
   //                        </xs:element>
   //                        <xs:element name = "LoadAxisViolation" maxOccurs= "unbounded" >
   //                              < xs:complexType>
   //                                    <xs:sequence>
   //                                          <xs:element name = "AxisNumber" type= "xs:int" ></ xs:element>
   //                                          <xs:element name = "LoadAxisFact" type= "xs:double" ></ xs:element>
   //                                          <xs:element name = "LoadAxisPermission" type= "xs:int" ></ xs:element>
   //                                          <xs:element name = "ExtraAxis" type= "xs:int" ></ xs:element>
   //                                          <xs:element name = "DifferenceNormFact" type= "xs:int" ></ xs:element>
   //                                          <xs:element name = "DifferencePermissionFact" type= "xs:int" ></ xs:element>
   //                                          <xs:element name = "SignExcessLoadAxis" type= "xs:string" ></ xs:element>
   //                                          <xs:element name = "AxisIntervalsNorm" type= "xs:string" ></ xs:element>
   //                                          <xs:element name = "AxisIntervalsPermission" type= "xs:int" ></ xs:element>
   //                                          <xs:element name = "AxisIntervalsFact" type= "xs:double" ></ xs:element>
   //                                          <xs:element name = "DiffInterPermissionFact" type= "xs:double" ></ xs:element>
   //                                          <xs:element name = "LoadAxisNormForFact" type= "xs:int" ></ xs:element>
   //                                          <xs:element name = "SignExcessIntervalAxis" type= "xs:string" ></ xs:element>
   //                                          <xs:element name = "AxisWheelsExFact" type= "xs:int" ></ xs:element>
   //                                          <xs:element name = "AxisWheelsNumFact" type= "xs:int" ></ xs:element>
   //                                    </xs:sequence>
   //                              </xs:complexType>
   //                        </xs:element>
   //                        <xs:element name = "FullWeightViolation" >
   //                              < xs:complexType>
   //                                    <xs:sequence>
   //                                          <xs:element name = "FullWeightNorm" type= "xs:int" ></ xs:element>
   //                                          <xs:element name = "ExtraFullWeight" type= "xs:int" ></ xs:element>
   //                                          <xs:element name = "FullWeightPermission" type= "xs:int" ></ xs:element>
   //                                          <xs:element name = "FullWeightFact" type= "xs:double" ></ xs:element>
   //                                          <xs:element name = "DifferenceFullWeightNormaFact" type= "xs:int" ></ xs:element>
   //                                          <xs:element name = "DifferenceFullWeightPermissionFact" type= "xs:int" ></ xs:element>
   //                                    </xs:sequence>
   //                              </xs:complexType>
   //                        </xs:element>
   //                        <xs:element name = "ActPdf" type= "xs:string" ></ xs:element>
   //                  </xs:sequence>
   //                  <xs:attribute name = "xmlns:xsd" type= "xs:string" ></ xs:attribute>
   //                  <xs:attribute name = "xmlns:xsi" type= "xs:string" ></ xs:attribute>
   //                  <xs:attribute name = "xmlns" type= "xs:string" ></ xs:attribute>
   //            </xs:complexType>
   //      </xs:element>
   //</xs:schema>
    }
}
