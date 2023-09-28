using Microsoft.AspNetCore.Mvc;

namespace Test.Srvr;

public class SomeController : ControllerBase {

  [HttpGet("ctrl/hi")]
  public ActionResult SomeMethod(int? x)
    => Ok($"router works, x={(x is null ? "null": x)}");
}
