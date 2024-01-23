using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Models;
using Dapper.Services;
using ExampleAPI.Models;
using Microsoft.AspNetCore.Mvc;


namespace Dapper.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserServices _userServices;
        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }
        [Route("FindUsers")]
        [HttpGet]
        public async Task<Response>FindUsers()
        {
            try
            {
                var findUsers = await _userServices.FindUsers();
                if (findUsers.Count > 0)
                {
                    Response resnponse = new Response
                    {
                        Message = new Message
                        {
                            Code = "200",
                            Detail = "Successfully",
                            Display = new Display
                            {
                                TH = "สำเร็จ",
                                EN = "Successfully"
                            }
                        },
                        Result = findUsers
                    };
                    return resnponse;

                }
                else
                {
                    Response resnponse = new Response
                    {
                        Message = new Message
                        {
                            Code = "200",
                            Detail = "Fail",
                            Display = new Display
                            {
                                TH = "สำเร็จ",
                                EN = "ไม่มีข้อมูล"
                            }
                        },
                        Result = findUsers
                    };
                    return resnponse;
                }
            }
            catch (Exception ex)
            {
                Response responseCatch = new Response
                {
                    Message = new Message
                    {
                        Code = "400",
                        Detail = ex.ToString(),
                        Display = new Display
                        {
                            TH = "เกิดข้อผิดพลาด",
                            EN = "Bad Request"
                        }
                    }
                };
                return responseCatch;
            }
        }

        [Route("GetById/{id}")]
        [HttpGet]
        public async Task<Response> GetById(int id)
        {
            try
            {
                var findUsers = await _userServices.FindUserById(id);
                if (findUsers != null)
                {
                    Response resnponse = new Response
                    {
                        Message = new Message
                        {
                            Code = "200",
                            Detail = "Successfully",
                            Display = new Display
                            {
                                TH = "สำเร็จ",
                                EN = "Successfully"
                            }
                        },
                        Result = findUsers
                    };
                    return resnponse;

                }
                else
                {
                    Response resnponse = new Response
                    {
                        Message = new Message
                        {
                            Code = "200",
                            Detail = "Fail",
                            Display = new Display
                            {
                                TH = "สำเร็จ",
                                EN = "ไม่มีข้อมูล"
                            }
                        },
                        Result = findUsers
                    };
                    return resnponse;
                }
            }
            catch (Exception ex)
            {
                Response responseCatch = new Response
                {
                    Message = new Message
                    {
                        Code = "400",
                        Detail = ex.ToString(),
                        Display = new Display
                        {
                            TH = "เกิดข้อผิดพลาด",
                            EN = "Bad Request"
                        }
                    }
                };
                return responseCatch;
            }
        }

        [Route("InsertUser")]
        [HttpPost]
        public Response Post([FromBody] InsertModel request)
        {
            try
            {
                var findUsers =  _userServices.Insert(request);
                if (findUsers != null)
                {
                    Response resnponse = new Response
                    {
                        Message = new Message
                        {
                            Code = "200",
                            Detail = "Successfully",
                            Display = new Display
                            {
                                TH = "สำเร็จ",
                                EN = "Successfully"
                            }
                        },
                        Result = findUsers
                    };
                    return resnponse;

                }
                else
                {
                    Response resnponse = new Response
                    {
                        Message = new Message
                        {
                            Code = "200",
                            Detail = "Fail",
                            Display = new Display
                            {
                                TH = "สำเร็จ",
                                EN = "ไม่มีข้อมูล"
                            }
                        },
                        Result = findUsers
                    };
                    return resnponse;
                }
            }
            catch (Exception ex)
            {
                Response responseCatch = new Response
                {
                    Message = new Message
                    {
                        Code = "400",
                        Detail = ex.ToString(),
                        Display = new Display
                        {
                            TH = "เกิดข้อผิดพลาด",
                            EN = "Bad Request"
                        }
                    }
                };
                return responseCatch;
            }
        }

        [Route("UpdateUser")]
        [HttpPost]
        public Response Update([FromBody] UpdateModel request)
        {
            try
            {
                var findUsers = _userServices.Update(request);
                if (findUsers != null)
                {
                    Response resnponse = new Response
                    {
                        Message = new Message
                        {
                            Code = "200",
                            Detail = "Successfully",
                            Display = new Display
                            {
                                TH = "สำเร็จ",
                                EN = "Successfully"
                            }
                        },
                        Result = findUsers
                    };
                    return resnponse;

                }
                else
                {
                    Response resnponse = new Response
                    {
                        Message = new Message
                        {
                            Code = "200",
                            Detail = "Fail",
                            Display = new Display
                            {
                                TH = "สำเร็จ",
                                EN = "ไม่มีข้อมูล"
                            }
                        },
                        Result = findUsers
                    };
                    return resnponse;
                }
            }
            catch (Exception ex)
            {
                Response responseCatch = new Response
                {
                    Message = new Message
                    {
                        Code = "400",
                        Detail = ex.ToString(),
                        Display = new Display
                        {
                            TH = "เกิดข้อผิดพลาด",
                            EN = "Bad Request"
                        }
                    }
                };
                return responseCatch;
            }
        }

        [Route("Delete/{id}")]
        [HttpDelete]
        public Response DeleteById(int id)
        {
            try
            {
                var findUsers = _userServices.DeleteById(id);
                if (findUsers != null)
                {
                    Response resnponse = new Response
                    {
                        Message = new Message
                        {
                            Code = "200",
                            Detail = "Successfully",
                            Display = new Display
                            {
                                TH = "สำเร็จ",
                                EN = "Successfully"
                            }
                        },
                        Result = findUsers
                    };
                    return resnponse;

                }
                else
                {
                    Response resnponse = new Response
                    {
                        Message = new Message
                        {
                            Code = "200",
                            Detail = "Fail",
                            Display = new Display
                            {
                                TH = "สำเร็จ",
                                EN = "ไม่มีข้อมูล"
                            }
                        },
                        Result = findUsers
                    };
                    return resnponse;
                }
            }
            catch (Exception ex)
            {
                Response responseCatch = new Response
                {
                    Message = new Message
                    {
                        Code = "400",
                        Detail = ex.ToString(),
                        Display = new Display
                        {
                            TH = "เกิดข้อผิดพลาด",
                            EN = "Bad Request"
                        }
                    }
                };
                return responseCatch;
            }
        }
    }
}

