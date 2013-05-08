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
	
	public class m_video extends MovieClip {
		public var ns:NetStream;
		public var nc:NetConnection;
		public var video:Video;
		private var clientobj:Object;
		private var str:String;
		
		
		public function m_video() {
			stop();
			nc = new NetConnection();
			nc.addEventListener(NetStatusEvent.NET_STATUS,onNetStatus);
			nc.connect(null);
			this.addEventListener(Event.REMOVED_FROM_STAGE,remove);
			addFrameScript(19,ShowPlayerStopFun);
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
		
		//视频播放是的反馈信息
		private function NetStatusHandler(e:NetStatusEvent):void {
			if (e.info.code == "NetStream.Play.Stop") {
				ns.seek(0);
				ns.pause(); 
				//ns.play(str);
				//this.parent.B2play.visible=true;
                //this.parent.B2pause.visible=false;
				//this.parent as MovieClip.showB();
				MovieClip(this.root).EndPlayVideo();
			}
			//this.parent.
		}
		//mvd控件帧动画执行完后第一个函数
		private function ShowPlayerStopFun() {
			stop();
			addChild(video);
			video.visible = true;
			ns.play(str);
			ns.seek(0);
			//ns.pause(); 
		}
		//播放某个视频，mvd控件开始执行
		public function ShowVideo(st:String ) {
			ns.close();
			video.visible = false;
			this.str = st;
			this.gotoAndPlay(1);
		}
		public function CloseVideoNoFunc() {
			ns.seek(0);
			ns.pause(); 
			//ns.close();
			video.visible = false;
		}
		public function CloseVideo() {
			ns.close();
			video.visible = false;
			addFrameScript(39,CloseVideoFun);
			this.gotoAndPlay(21);		
			
		}
		
		function CloseVideoFun()
		{
			stop();
			MovieClip(this.root).FunctionCloseVideo();
		}
		
		public function PauseVideo() {
			ns.pause(); 
		}
		public function ResumeVideo() {
			ns.resume(); 
		}
		public function SetSize(w:int,h:int)
		{
			video.width = w;
			video.height = h;
		}
		private function remove(e) {
			ns.close();
		}
	}
}