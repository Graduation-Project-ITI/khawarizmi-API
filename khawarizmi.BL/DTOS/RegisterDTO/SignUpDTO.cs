﻿using khawarizmi.DAL.Datatypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace khawarizmi.BL;

public record SignUpDTO(string name,string email, string password,string role,Gender Gender);

