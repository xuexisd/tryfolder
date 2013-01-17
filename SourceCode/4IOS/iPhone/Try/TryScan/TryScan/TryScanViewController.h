//
//  TryScanViewController.h
//  TryScan
//
//  Created by yeetong on 12-12-19.
//  Copyright (c) 2012年 yeetong. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "ZBarSDK/ZBarSDK.h"

@interface TryScanViewController : UIViewController <ZBarReaderDelegate>
@property (strong, nonatomic) IBOutlet UITextView *txtResult;
- (IBAction)btnScan:(id)sender;

@end
