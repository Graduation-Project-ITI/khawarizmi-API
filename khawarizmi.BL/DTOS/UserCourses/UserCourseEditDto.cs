﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace khawarizmi.BL.Dtos;

public record UserCourseEditDto(int CourseId, string UserId, bool Boolean);
