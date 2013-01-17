//
//  Global.m
//  CloudContact
//
//  Created by yeetong on 12-10-24.
//  Copyright (c) 2012年 yeetong. All rights reserved.
//

#import "Global.h"

static NSString *_WCFHttpPath;
static NSString *_MBProgressWithSimpleLabelGet;

@implementation Global


+(NSString *)WCFHttpPathGet{
    return _WCFHttpPath;
}

+(void)SetAllAppConfig{
    NSString *path=[[NSBundle mainBundle] pathForResource:@"AppConfig" ofType:@"plist"];
    NSDictionary *dictGlobal=[[NSDictionary alloc]initWithContentsOfFile:path];
    _WCFHttpPath=[dictGlobal objectForKey:@"SunnyWCF"];
    _MBProgressWithSimpleLabelGet=[dictGlobal objectForKey:@"LoadingSimpleLabel"];
}

+(NSString *)MBProgressWithSimpleLabelGet
{
    return _MBProgressWithSimpleLabelGet;
}

@end
