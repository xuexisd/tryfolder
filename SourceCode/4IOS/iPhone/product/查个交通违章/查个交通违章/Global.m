//
//  Global.m
//  查个交通违章
//
//  Created by yeetong on 13-1-10.
//  Copyright (c) 2013年 yeetong. All rights reserved.
//

#import "Global.h"

static int _TotalCars;
static NSString *_ChooseCarNumber;
static NSString *_ChooseCarFrame;

@implementation Global

+(int)GetTotalCars
{
    return _TotalCars;
}
+(void)SetTotalCars:(int)totalCars
{
    _TotalCars = totalCars;
}

+(NSString *)GetChooseCarNumber
{
    return _ChooseCarNumber;
}
+(void)SetChooseCarNumber:(NSString *)carNumber
{
    _ChooseCarNumber = carNumber;
}

+(NSString *)GetChooseCarFrame
{
    return _ChooseCarFrame;
}
+(void)SetChooseCarFrame:(NSString *)carFrame
{
    _ChooseCarFrame = carFrame;
}

+(NSString *)GetUrlAddressCompleted
{
    return @"http://kongjiansd.62.zqname.info/SC.svc/SC/GetCompleted";
}
+(NSString *)GetUrlAddressUnprocessed
{
    return @"http://kongjiansd.62.zqname.info/SC.svc/SC/GetUnProcessed";
}

+(NSString *)MBProgressLoadingText
{
    return @"加载中...";
}

@end
