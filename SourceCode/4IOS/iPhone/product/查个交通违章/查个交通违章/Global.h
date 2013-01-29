//
//  Global.h
//  查个交通违章
//
//  Created by yeetong on 13-1-10.
//  Copyright (c) 2013年 yeetong. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface Global : NSObject

+(int)GetTotalCars;
+(void)SetTotalCars:(int)totalCars;

+(NSString *)GetChooseCarNumber;
+(void)SetChooseCarNumber:(NSString *)totalCars;

+(NSString *)GetUrlAddressCompleted;
+(NSString *)GetUrlAddressUnprocessed;

+(NSString *)GetChooseCarFrame;
+(void)SetChooseCarFrame:(NSString *)carFrame;

+(NSString *)MBProgressLoadingText;

@end
