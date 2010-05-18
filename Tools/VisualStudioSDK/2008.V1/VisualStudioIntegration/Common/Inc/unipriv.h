// unipriv.h -- UniLib private internal header

#ifdef _MSC_VER
#pragma once
#endif

#ifndef __UNIPRIV_H__
#define __UNIPRIV_H__

#undef UASSERT
#ifdef _DEBUG

#ifdef _X86_
#define __UBREAK__ _asm { int 3 }
#else
#define __UBREAK__ DebugBreak();
#endif // _X86_

#define UASSERT(exp) do { if (!(exp)) __UBREAK__; } while (FALSE)

#else // _DEBUG

#define UASSERT(exp) do {} while (false)

#endif // _DEBUG

#endif // __UNIPRIV_H__
