ogram Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Facades\System.Threading.Tasks.dll�  ~C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Facades\System.Threading.Tasks.Parallel.dll�  vC:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Facades\System.Threading.Thread.dll�  zC:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Facades\System.Threading.ThreadPool.dll�  uC:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Facades\System.Threading.Timer.dll�  pC:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Facades\System.ValueTuple.dll�  sC:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Facades\System.Xml.XDocument.dll�  uC:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Facades\System.Xml.XmlDocument.dll�  wC:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Facades\System.Xml.XmlSerializer.dll�  oC:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Facades\System.Xml.XPath.dll�  yC:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Facades\System.Xml.XPath.XDocument.dll   �System.Collections.Generic.List`1[[System.Collections.Generic.KeyValuePair`2[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089],[System.Collections.Generic.List`1[[System.Collections.Generic.KeyValuePair`2[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089],[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   _items_size_version  �System.Collections.Generic.KeyValuePair`2[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089],[System.Collections.Generic.List`1[[System.Collections.Generic.KeyValuePair`2[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089],[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]][]	�                �  SC:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\      �  Full      	�          	      	�          
             �  {CandidateAssemblyFiles}�  {HintPathFromItem}�  {TargetFrameworkDirectory}�  B{Registry:Software\Microsoft\.NETFramework,v4.8,AssemblyFoldersEx}�  {RawFileName}�  KD:\Application\Web\ASP.NET\MVC\ViewPlusSubsBooster\ViewPlusSubsBooster\bin\      �  SC:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\�  [C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Facades\       �          �System.Collections.Generic.KeyValuePair`2[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089],[System.Collections.Generic.List`1[[System.Collections.Generic.KeyValuePair`2[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089],[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]                                                                                                                                                                                                                                                       d", model.CreatedbyUserId);
            parameters.Add("@id", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
            db.Execute("sp_RegisterUser", parameters, commandType: CommandType.StoredProcedure);
            int id = parameters.Get<int>("@id");
            return id;
        }

        public LoginModel ValidateUser(LoginModel model)
        {
            try
            {
                LoginModel response = new LoginModel();
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@UserName", model.UserName);
                ObjParm.Add("@Password", model.Password);
                response = (LoginModel)Repose.GetSingleModel<LoginModel>("sp_Login", ObjParm);
                return response;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}