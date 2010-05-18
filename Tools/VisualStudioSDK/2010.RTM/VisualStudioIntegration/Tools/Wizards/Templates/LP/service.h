#ifndef service_h
#define service_h

#include <common.h>
#include <languagedef.h>
#include <stdservice.h>


class Service : public CommentService
{
protected:
  %CommentFormatDecl%
  override const TokenInfo*     getTokenInfo()     const;
};


#endif