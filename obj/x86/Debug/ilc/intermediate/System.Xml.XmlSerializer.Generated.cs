namespace System.Runtime.CompilerServices {
    internal class __BlockReflectionAttribute : Attribute { }
}

namespace Microsoft.Xml.Serialization.GeneratedAssembly {


    [System.Runtime.CompilerServices.__BlockReflection]
    public class XmlSerializationWriter1 : System.Xml.Serialization.XmlSerializationWriter {

        public void Write3_ArrayOfPersistModel(object o, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs ?? @"";
            WriteStartDocument();
            if (o == null) {
                WriteNullTagLiteral(@"ArrayOfPersistModel", defaultNamespace);
                return;
            }
            TopLevelElement();
            string namespace1 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            {
                global::System.Collections.Generic.List<global::NavigationMenuSample.Models.PersistModel> a = (global::System.Collections.Generic.List<global::NavigationMenuSample.Models.PersistModel>)((global::System.Collections.Generic.List<global::NavigationMenuSample.Models.PersistModel>)o);
                if ((object)(a) == null) {
                    WriteNullTagLiteral(@"ArrayOfPersistModel", defaultNamespace);
                }
                else {
                    WriteStartElement(@"ArrayOfPersistModel", namespace1, null, false);
                    for (int ia = 0; ia < ((System.Collections.ICollection)a).Count; ia++) {
                        string namespace2 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
                        Write2_PersistModel(@"PersistModel", namespace2, ((global::NavigationMenuSample.Models.PersistModel)a[ia]), true, false, namespace2, @"");
                    }
                    WriteEndElement();
                }
            }
        }

        public void Write4_anyType(object o, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs ?? @"";
            WriteStartDocument();
            if (o == null) {
                WriteNullTagLiteral(@"anyType", defaultNamespace);
                return;
            }
            TopLevelElement();
            string namespace3 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            Write1_Object(@"anyType", namespace3, ((global::System.Object)o), true, false, namespace3, @"");
        }

        public void Write5_anyType(object o, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs ?? @"";
            WriteStartDocument();
            if (o == null) {
                WriteNullTagLiteral(@"anyType", defaultNamespace);
                return;
            }
            TopLevelElement();
            string namespace4 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            Write1_Object(@"anyType", namespace4, ((global::System.Object)o), true, false, namespace4, @"");
        }

        void Write1_Object(string n, string ns, global::System.Object o, bool isNullable, bool needType, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs;
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::System.Object)) {
                }
                else if (t == typeof(global::NavigationMenuSample.Models.PersistModel)) {
                    Write2_PersistModel(n, ns,(global::NavigationMenuSample.Models.PersistModel)o, isNullable, true);
                    return;
                }
                else if (t == typeof(global::System.Collections.Generic.List<global::NavigationMenuSample.Models.PersistModel>)) {
                    Writer.WriteStartElement(n, ns);
                    WriteXsiType(@"ArrayOfPersistModel", @"");
                    {
                        global::System.Collections.Generic.List<global::NavigationMenuSample.Models.PersistModel> a = (global::System.Collections.Generic.List<global::NavigationMenuSample.Models.PersistModel>)o;
                        if (a != null) {
                            for (int ia = 0; ia < ((System.Collections.ICollection)a).Count; ia++) {
                                string namespace5 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
                                Write2_PersistModel(@"PersistModel", namespace5, ((global::NavigationMenuSample.Models.PersistModel)a[ia]), true, false, namespace5, @"");
                            }
                        }
                    }
                    Writer.WriteEndElement();
                    return;
                }
                else {
                    WriteTypedPrimitive(n, ns, o, true);
                    return;
                }
            }
            WriteStartElement(n, ns, o, false, null);
            WriteEndElement(o);
        }

        void Write2_PersistModel(string n, string ns, global::NavigationMenuSample.Models.PersistModel o, bool isNullable, bool needType, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs;
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::NavigationMenuSample.Models.PersistModel)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"PersistModel", defaultNamespace);
            string namespace6 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementString(@"UserID", namespace6, ((global::System.String)o.@UserID));
            string namespace7 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementString(@"ScreenName", namespace7, ((global::System.String)o.@ScreenName));
            string namespace8 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementString(@"AccessToken", namespace8, ((global::System.String)o.@AccessToken));
            string namespace9 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementString(@"AccessSecretToken", namespace9, ((global::System.String)o.@AccessSecretToken));
            WriteEndElement(o);
        }

        protected override void InitCallbacks() {
        }
    }

    [System.Runtime.CompilerServices.__BlockReflection]
    public class XmlSerializationReader1 : System.Xml.Serialization.XmlSerializationReader {

        public object Read3_ArrayOfPersistModel(string defaultNamespace = null) {
            object o = null;
            Reader.MoveToContent();
            if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                if (((object) Reader.LocalName == (object)id1_ArrayOfPersistModel && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                    if (!ReadNull()) {
                        if ((object)(o) == null) o = new global::System.Collections.Generic.List<global::NavigationMenuSample.Models.PersistModel>();
                        global::System.Collections.Generic.List<global::NavigationMenuSample.Models.PersistModel> a_0_0 = (global::System.Collections.Generic.List<global::NavigationMenuSample.Models.PersistModel>)o;
                        if ((Reader.IsEmptyElement)) {
                            Reader.Skip();
                        }
                        else {
                            Reader.ReadStartElement();
                            Reader.MoveToContent();
                            int whileIterations0 = 0;
                            int readerCount0 = ReaderCount;
                            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                                    if (((object) Reader.LocalName == (object)id3_PersistModel && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                                        if ((object)(a_0_0) == null) Reader.Skip(); else a_0_0.Add(Read2_PersistModel(true, true, defaultNamespace));
                                    }
                                    else {
                                        UnknownNode(null, @":PersistModel");
                                    }
                                }
                                else {
                                    UnknownNode(null, @":PersistModel");
                                }
                                Reader.MoveToContent();
                                CheckReaderCount(ref whileIterations0, ref readerCount0);
                            }
                        ReadEndElement();
                        }
                    }
                    else {
                        if ((object)(o) == null) o = new global::System.Collections.Generic.List<global::NavigationMenuSample.Models.PersistModel>();
                        global::System.Collections.Generic.List<global::NavigationMenuSample.Models.PersistModel> a_0_0 = (global::System.Collections.Generic.List<global::NavigationMenuSample.Models.PersistModel>)o;
                    }
                }
                else {
                    throw CreateUnknownNodeException();
                }
            }
            else {
                UnknownNode(null, defaultNamespace ?? @":ArrayOfPersistModel");
            }
            return (object)o;
        }

        public object Read4_anyType(string defaultNamespace = null) {
            object o = null;
            Reader.MoveToContent();
            if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                if (((object) Reader.LocalName == (object)id4_anyType && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                    o = Read1_Object(true, true, defaultNamespace);
                }
                else {
                    throw CreateUnknownNodeException();
                }
            }
            else {
                UnknownNode(null, defaultNamespace ?? @":anyType");
            }
            return (object)o;
        }

        public object Read5_anyType(string defaultNamespace = null) {
            object o = null;
            Reader.MoveToContent();
            if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                if (((object) Reader.LocalName == (object)id4_anyType && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                    o = Read1_Object(true, true, defaultNamespace);
                }
                else {
                    throw CreateUnknownNodeException();
                }
            }
            else {
                UnknownNode(null, defaultNamespace ?? @":anyType");
            }
            return (object)o;
        }

        global::System.Object Read1_Object(bool isNullable, bool checkType, string defaultNamespace = null) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
                if (isNull) {
                    if (xsiType != null) return (global::System.Object)ReadTypedNull(xsiType);
                    else return null;
                }
                if (xsiType == null) {
                    return ReadTypedPrimitive(new System.Xml.XmlQualifiedName("anyType", "http://www.w3.org/2001/XMLSchema"));
                }
                else if (((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id3_PersistModel && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id2_Item)))
                    return Read2_PersistModel(isNullable, false, defaultNamespace);
                else if (((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id1_ArrayOfPersistModel && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id2_Item))) {
                    global::System.Collections.Generic.List<global::NavigationMenuSample.Models.PersistModel> a = null;
                    if (!ReadNull()) {
                        if ((object)(a) == null) a = new global::System.Collections.Generic.List<global::NavigationMenuSample.Models.PersistModel>();
                        global::System.Collections.Generic.List<global::NavigationMenuSample.Models.PersistModel> z_0_0 = (global::System.Collections.Generic.List<global::NavigationMenuSample.Models.PersistModel>)a;
                        if ((Reader.IsEmptyElement)) {
                            Reader.Skip();
                        }
                        else {
                            Reader.ReadStartElement();
                            Reader.MoveToContent();
                            int whileIterations1 = 0;
                            int readerCount1 = ReaderCount;
                            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                                    if (((object) Reader.LocalName == (object)id3_PersistModel && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                                        if ((object)(z_0_0) == null) Reader.Skip(); else z_0_0.Add(Read2_PersistModel(true, true, defaultNamespace));
                                    }
                                    else {
                                        UnknownNode(null, @":PersistModel");
                                    }
                                }
                                else {
                                    UnknownNode(null, @":PersistModel");
                                }
                                Reader.MoveToContent();
                                CheckReaderCount(ref whileIterations1, ref readerCount1);
                            }
                        ReadEndElement();
                        }
                    }
                    return a;
                }
                else
                    return ReadTypedPrimitive((System.Xml.XmlQualifiedName)xsiType);
                }
                if (isNull) return null;
                global::System.Object o;
                o = new global::System.Object();
                bool[] paramsRead = new bool[0];
                while (Reader.MoveToNextAttribute()) {
                    if (!IsXmlnsAttribute(Reader.Name)) {
                        UnknownNode((object)o);
                    }
                }
                Reader.MoveToElement();
                if (Reader.IsEmptyElement) {
                    Reader.Skip();
                    return o;
                }
                Reader.ReadStartElement();
                Reader.MoveToContent();
                int whileIterations2 = 0;
                int readerCount2 = ReaderCount;
                while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                    if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                        UnknownNode((object)o, @"");
                    }
                    else {
                        UnknownNode((object)o, @"");
                    }
                    Reader.MoveToContent();
                    CheckReaderCount(ref whileIterations2, ref readerCount2);
                }
                ReadEndElement();
                return o;
            }

            global::NavigationMenuSample.Models.PersistModel Read2_PersistModel(bool isNullable, bool checkType, string defaultNamespace = null) {
                System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
                bool isNull = false;
                if (isNullable) isNull = ReadNull();
                if (checkType) {
                if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id3_PersistModel && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id2_Item))) {
                }
                else
                    throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
                }
                if (isNull) return null;
                global::NavigationMenuSample.Models.PersistModel o;
                o = new global::NavigationMenuSample.Models.PersistModel();
                bool[] paramsRead = new bool[4];
                while (Reader.MoveToNextAttribute()) {
                    if (!IsXmlnsAttribute(Reader.Name)) {
                        UnknownNode((object)o);
                    }
                }
                Reader.MoveToElement();
                if (Reader.IsEmptyElement) {
                    Reader.Skip();
                    return o;
                }
                Reader.ReadStartElement();
                Reader.MoveToContent();
                int whileIterations3 = 0;
                int readerCount3 = ReaderCount;
                while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                    if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                        if (!paramsRead[0] && ((object) Reader.LocalName == (object)id5_UserID && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                            {
                                o.@UserID = Reader.ReadElementContentAsString();
                            }
                            paramsRead[0] = true;
                        }
                        else if (!paramsRead[1] && ((object) Reader.LocalName == (object)id6_ScreenName && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                            {
                                o.@ScreenName = Reader.ReadElementContentAsString();
                            }
                            paramsRead[1] = true;
                        }
                        else if (!paramsRead[2] && ((object) Reader.LocalName == (object)id7_AccessToken && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                            {
                                o.@AccessToken = Reader.ReadElementContentAsString();
                            }
                            paramsRead[2] = true;
                        }
                        else if (!paramsRead[3] && ((object) Reader.LocalName == (object)id8_AccessSecretToken && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                            {
                                o.@AccessSecretToken = Reader.ReadElementContentAsString();
                            }
                            paramsRead[3] = true;
                        }
                        else {
                            UnknownNode((object)o, @":UserID, :ScreenName, :AccessToken, :AccessSecretToken");
                        }
                    }
                    else {
                        UnknownNode((object)o, @":UserID, :ScreenName, :AccessToken, :AccessSecretToken");
                    }
                    Reader.MoveToContent();
                    CheckReaderCount(ref whileIterations3, ref readerCount3);
                }
                ReadEndElement();
                return o;
            }

            protected override void InitCallbacks() {
            }

            string id2_Item;
            string id3_PersistModel;
            string id5_UserID;
            string id7_AccessToken;
            string id6_ScreenName;
            string id1_ArrayOfPersistModel;
            string id8_AccessSecretToken;
            string id4_anyType;

            protected override void InitIDs() {
                id2_Item = Reader.NameTable.Add(@"");
                id3_PersistModel = Reader.NameTable.Add(@"PersistModel");
                id5_UserID = Reader.NameTable.Add(@"UserID");
                id7_AccessToken = Reader.NameTable.Add(@"AccessToken");
                id6_ScreenName = Reader.NameTable.Add(@"ScreenName");
                id1_ArrayOfPersistModel = Reader.NameTable.Add(@"ArrayOfPersistModel");
                id8_AccessSecretToken = Reader.NameTable.Add(@"AccessSecretToken");
                id4_anyType = Reader.NameTable.Add(@"anyType");
            }
        }

        [System.Runtime.CompilerServices.__BlockReflection]
        public abstract class XmlSerializer1 : System.Xml.Serialization.XmlSerializer {
            protected override System.Xml.Serialization.XmlSerializationReader CreateReader() {
                return new XmlSerializationReader1();
            }
            protected override System.Xml.Serialization.XmlSerializationWriter CreateWriter() {
                return new XmlSerializationWriter1();
            }
        }

        [System.Runtime.CompilerServices.__BlockReflection]
        public sealed class ListOfPersistModelSerializer : XmlSerializer1 {

            public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
                return xmlReader.IsStartElement(@"ArrayOfPersistModel", this.DefaultNamespace ?? @"");
            }

            protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
                ((XmlSerializationWriter1)writer).Write3_ArrayOfPersistModel(objectToSerialize, this.DefaultNamespace, @"");
            }

            protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
                return ((XmlSerializationReader1)reader).Read3_ArrayOfPersistModel(this.DefaultNamespace);
            }
        }

        [System.Runtime.CompilerServices.__BlockReflection]
        public sealed class ObjectSerializer : XmlSerializer1 {

            public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
                return xmlReader.IsStartElement(@"anyType", this.DefaultNamespace ?? @"");
            }

            protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
                ((XmlSerializationWriter1)writer).Write4_anyType(objectToSerialize, this.DefaultNamespace, @"");
            }

            protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
                return ((XmlSerializationReader1)reader).Read4_anyType(this.DefaultNamespace);
            }
        }

        [System.Runtime.CompilerServices.__BlockReflection]
        public class XmlSerializerContract : global::System.Xml.Serialization.XmlSerializerImplementation {
            public override global::System.Xml.Serialization.XmlSerializationReader Reader { get { return new XmlSerializationReader1(); } }
            public override global::System.Xml.Serialization.XmlSerializationWriter Writer { get { return new XmlSerializationWriter1(); } }
            System.Collections.IDictionary readMethods = null;
            public override System.Collections.IDictionary ReadMethods {
                get {
                    if (readMethods == null) {
                        System.Collections.IDictionary _tmp = new System.Collections.Generic.Dictionary<string, string>();
                        _tmp[@"System.Collections.Generic.List`1[[NavigationMenuSample.Models.PersistModel, KunappWinApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]::"] = @"Read3_ArrayOfPersistModel";
                        _tmp[@"System.Object::"] = @"Read4_anyType";
                        _tmp[@"System.Object::"] = @"Read5_anyType";
                        if (readMethods == null) readMethods = _tmp;
                    }
                    return readMethods;
                }
            }
            System.Collections.IDictionary writeMethods = null;
            public override System.Collections.IDictionary WriteMethods {
                get {
                    if (writeMethods == null) {
                        System.Collections.IDictionary _tmp = new System.Collections.Generic.Dictionary<string, string>();
                        _tmp[@"System.Collections.Generic.List`1[[NavigationMenuSample.Models.PersistModel, KunappWinApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]::"] = @"Write3_ArrayOfPersistModel";
                        _tmp[@"System.Object::"] = @"Write4_anyType";
                        _tmp[@"System.Object::"] = @"Write5_anyType";
                        if (writeMethods == null) writeMethods = _tmp;
                    }
                    return writeMethods;
                }
            }
            System.Collections.IDictionary typedSerializers = null;
            public override System.Collections.IDictionary TypedSerializers {
                get {
                    if (typedSerializers == null) {
                        System.Collections.IDictionary _tmp = new System.Collections.Generic.Dictionary<string, System.Xml.Serialization.XmlSerializer>();
                        _tmp.Add(@"System.Collections.Generic.List`1[[NavigationMenuSample.Models.PersistModel, KunappWinApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]::", new ListOfPersistModelSerializer());
                        _tmp.Add(@"System.Object::", new ObjectSerializer());
                        if (typedSerializers == null) typedSerializers = _tmp;
                    }
                    return typedSerializers;
                }
            }
            public override System.Boolean CanSerialize(System.Type type) {
                if (type == typeof(global::System.Collections.Generic.List<global::NavigationMenuSample.Models.PersistModel>)) return true;
                if (type == typeof(global::System.Object)) return true;
                if (type == typeof(global::System.Reflection.TypeInfo)) return true;
                return false;
            }
            public override System.Xml.Serialization.XmlSerializer GetSerializer(System.Type type) {
                if (type == typeof(global::System.Collections.Generic.List<global::NavigationMenuSample.Models.PersistModel>)) return new ListOfPersistModelSerializer();
                if (type == typeof(global::System.Object)) return new ObjectSerializer();
                if (type == typeof(global::System.Object)) return new ObjectSerializer();
                return null;
            }
            public static global::System.Xml.Serialization.XmlSerializerImplementation GetXmlSerializerContract() { return new XmlSerializerContract(); }
        }

        [System.Runtime.CompilerServices.__BlockReflection]
        public static class ActivatorHelper {
            public static object CreateInstance(System.Type type) {
                System.Reflection.TypeInfo ti = System.Reflection.IntrospectionExtensions.GetTypeInfo(type);
                foreach (System.Reflection.ConstructorInfo ci in ti.DeclaredConstructors) {
                    if (!ci.IsStatic && ci.GetParameters().Length == 0) {
                        return ci.Invoke(null);
                    }
                }
                return System.Activator.CreateInstance(type);
            }
        }
    }
