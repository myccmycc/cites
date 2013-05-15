package {
	import flash.events.NetStatusEvent;
	import flash.media.Video;
	import flash.net.NetConnection;
	import flash.net.NetStream;
	import flash.events.MouseEvent;
	import flash.display.Sprite;
	import flash.display.MovieClip;
	import flash.events.Event;
	import flash.media.SoundMixer;
	
	public class m_video_normal2 extends MovieClip {
		public var ns:NetStream;
		public var nc:NetConnection;
		public var video:Video;
		private var clientobj:Object;
		private var str:String;
		
		
		public function m_video_normal2() {
			stop();
			nc = new NetConnection();
			nc.addEventListener(NetStatusEvent.NET_STATUS,onNetStatus);
			nc.connect(null);
			this.addEventListener(Event.REMOVED_FROM_STAGE,remove);
			addFrameScript(5,ShowPlayerStopFun);
		}
		private function onNetStatus(event:NetStatusEvent):void {
			if (event.info.code == "NetConnection.Connect.Success") {
				ns = new NetStream(event.target as NetConnection);
				ns.addEventListener(NetStatusEvent.NET_STATUS,NetStatusHandler);
				clientobj=new Object();
				clientobj.onMetaData = function(){};
				ns.client = clientobj;
				video = new Video();
				video.attachNetStream(ns);
				video.width = 1920;
				video.height = 1080;
				ns.bufferTime=3;
			}
		}
		
		//视频播放时反馈信息
		private function NetStatusHandler(e:NetStatusEvent):void {
		
		  //视频播放结束时
			if (e.info.code == "NetStream.Play.Stop") {
				ns.seek(0);
				ns.pause(); 
				MovieClip(this.parent).EndPlayVideo();
			}

		}
		//mvd控件帧动画执行完后第一个函数
		private function ShowPlayerStopFun() {
			stop();
			addChild(video);
			video.visible = true;
			ns.play(str);
			ns.seek(0);
			//ns.pause(); 
			trace("mv控件 视频开始播放");
		}
		//播放某个视频，mvd控件开始执行
		public function ShowVideo(st:String ) {
			ns.close();
			video.visible = false;
			this.str = st;
			this.gotoAndPlay(1);
		}

		public function PauseVideo() {
			ns.pause(); 
		}
		public function ResumeVideo() {
			ns.resume(); 
		}
		

		private function remove(e) {
			trace("remove moive");
			ns.close();
		}
		
		public function SetSize(w:int,h:int)
		{
			video.width = w;
			video.height = h;
		}
	}
}