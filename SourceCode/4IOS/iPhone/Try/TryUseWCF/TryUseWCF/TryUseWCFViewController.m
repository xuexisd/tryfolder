//
//  TryUseWCFViewController.m
//  TryUseWCF
//
//  Created by yeetong on 12-10-6.
//  Copyright (c) 2012年 yeetong. All rights reserved.
//

#import "TryUseWCFViewController.h"
#import "ASIHTTPRequest/ASIHTTPRequest.h"

@interface TryUseWCFViewController ()

@end

@implementation TryUseWCFViewController
@synthesize txt1;

- (void)viewDidLoad
{
    [super viewDidLoad];
	// Do any additional setup after loading the view, typically from a nib.
    
    NSURL *url=[NSURL URLWithString:@"http://192.168.1.102/TryPerformanceSunnyWCFHost/OperDB.svc/GetOneRecordByJson"];
    ASIHTTPRequest *request=[ASIHTTPRequest requestWithURL:url];
    [request startSynchronous];
    NSError *error=[request error];
    if(!error)
    {
        NSString *response=[request responseString];
        txt1.text=response;
    }
    
}

- (void)viewDidUnload
{
    [self setTxt1:nil];
    [super viewDidUnload];
    // Release any retained subviews of the main view.
}

- (BOOL)shouldAutorotateToInterfaceOrientation:(UIInterfaceOrientation)interfaceOrientation
{
    return (interfaceOrientation != UIInterfaceOrientationPortraitUpsideDown);
}

@end
