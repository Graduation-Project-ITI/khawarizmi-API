using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace khawarizmi.BL.Dtos.Helpers;
public record PaginationDisplayDto<T>(int Length, List<T> Data);
