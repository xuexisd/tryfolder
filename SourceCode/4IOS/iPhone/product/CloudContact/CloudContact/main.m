//
//  main.m
//  CloudContact
//
//  Created by yeetong on 12-10-11.
//  Copyright (c) 2012年 yeetong. All rights reserved.
//

#import <UIKit/UIKit.h>

#import "CloudContactAppDelegate.h"
#import "Global.h"

int main(int argc, char *argv[])
{
    @autoreleasepool {
        //start Global
        [Global SetAllAppConfig];
        //end Global
        return UIApplicationMain(argc, argv, nil, NSStringFromClass([CloudContactAppDelegate class]));
    }
}
